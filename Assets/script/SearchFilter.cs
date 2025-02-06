using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SearchFilter : MonoBehaviour
{
    public InputField searchField;  // Reference to the search bar
    public Transform content;       // Reference to the ScrollView's Content (list of items)

    private GameObject[] allItems;  // Array to store all list items

    void Start()
    {
        // Store all child objects (list items) under the content
        allItems = content.Cast<Transform>().Select(t => t.gameObject).ToArray();

        // Add a listener to the searchField to detect changes in input
        searchField.onValueChanged.AddListener(OnSearchValueChanged);
    }

    void OnSearchValueChanged(string searchText)
    {
        // Convert search text to lowercase for case-insensitive comparison
        searchText = searchText.ToLower();

        // Filter the matching items based on the search input
        var matchingItems = allItems
            .Where(item => item.name.ToLower().Contains(searchText))  // Match items containing the search text
            .OrderBy(item => item.name.ToLower().IndexOf(searchText))  // Prioritize items with closer matches
            .ToList();

        // Rearrange the sibling index of matching items and display them
        int siblingIndex = 0;

        foreach (var item in matchingItems)
        {
            item.SetActive(true);  // Activate matching items
            item.transform.SetSiblingIndex(siblingIndex);  // Move matching item to the top
            siblingIndex++;
        }

        // Hide non-matching items
        foreach (var item in allItems.Except(matchingItems))
        {
            item.SetActive(false);  // Deactivate non-matching items
        }

        // Rebuild the layout after rearranging items
        LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());
    }
}
