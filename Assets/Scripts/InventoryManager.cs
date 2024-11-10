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

    // Start is called before the first frame update
    void Start()
    {
        inventoryItems = FindObjectsOfType<InventoryItem>().ToList();
        populateInventory();
        SearchBarName();
        BinarySearch(searchID);
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
            
            if (searchID == mid)
            {
                Debug.Log(searchID + " Was Found!");
                return mid;
            }
            else if (mid < searchID)
            {
                left = mid + 1;
            }
            else if (mid > searchID)
            {
                right = mid - 1;
            }
        }

        Debug.Log("Item " + searchID + " Was Not Found :(");
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
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            inventoryItems[i].ID = Random.Range(101, 111);
            string name = inventoryItems[i].Name;
            inventoryItems[i].Value = Random.Range(1, 10000);

            InventoryItem item = new InventoryItem(inventoryItems[i].ID, name, inventoryItems[i].Value);
            inventoryItems.Add(item);
            Debug.Log("Name: " + name + "  ID: " + inventoryItems[i].ID + "  Value: " + inventoryItems[i].Value);
        }
    }
}
