using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItem> inventoryItems = new List<InventoryItem>();

    [Tooltip("Pick a inventory item name from the list of items in inspector")]
    public string searchName;

    [Tooltip("Pick a value between 101 and 111")] 
    public int searchID;
    public int totalValue;
    public int minValue;
    public int maxValue;

    // Start is called before the first frame update
    void Start()
    {
        inventoryItems = FindObjectsOfType<InventoryItem>().ToList();
        populateInventory();
        QuickSortByValue();
        CalculateTotalInventoryValue();
        FilterItemsByValueRange(minValue, maxValue);
        SearchBarName();
        BinarySearch(searchID);
    }

    public void QuickSortByValue()
    {
        inventoryItems.Sort((item1, item2) => item1.ID.CompareTo(item2.ID));
    }

    public int CalculateTotalInventoryValue()
    { 
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            totalValue += inventoryItems[i].Value;
        }
        Debug.Log("Total Value = " + totalValue);
        return totalValue;
    }

    public List<InventoryItem> FilterItemsByValueRange(int minValue, int maxValue)
    {
        List<InventoryItem> filteredItems = new List<InventoryItem>();

        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].Value >= minValue && inventoryItems[i].Value <= maxValue)
            {
                filteredItems.Add(inventoryItems[i]);
                Debug.Log(inventoryItems[i] + "added to filtered items list");
            }
        }

        return filteredItems;
    }

        public void SearchBarName()
    {
        InventoryItem foundItem = LinearSearchByName(searchName);

        if (foundItem != null)
        {
            Debug.Log(searchName + " was found!");
        }
        else
        {
            Debug.Log("Could not find " + searchName);
        }
    }

    public int BinarySearch(int itemID)
    {
        int left = 0;
        int right = inventoryItems.Count - 1;

        while (left < right)
        {
            int mid = (left + right) / 2;
            if (inventoryItems[mid].ID == searchID)
            {
                Debug.Log("ID: " + searchID + " Was Found in Element" + mid);

                return mid;
            }
            else if (inventoryItems[mid].ID < searchID)
            {
                left = mid + 1;
            }
            else if (inventoryItems[mid].ID > searchID)
            {
                right = mid - 1;
            }
        }
        return -1;
    }

    public InventoryItem LinearSearchByName(string itemName)
    {
        foreach (var item in inventoryItems)
        {
            if (item.Name == itemName)
                return item;
        }

        return null;
    }

    void populateInventory()
    {
        for (int i = 0; i < 10; i++)
        {
            inventoryItems[i].ID = Random.Range(101, 111);
            string name = inventoryItems[i].Name;
            inventoryItems[i].Value = Random.Range(1, 10000);

            InventoryItem item = new InventoryItem(inventoryItems[i].ID, name, inventoryItems[i].Value);
            //inventoryItems.Add(item); instantiates item
            Debug.Log("Name: " + name + "  ID: " + inventoryItems[i].ID + "  Value: " + inventoryItems[i].Value);
        }
    }
}
