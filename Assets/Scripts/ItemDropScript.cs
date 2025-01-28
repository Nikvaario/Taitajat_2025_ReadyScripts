using System.Collections.Generic;
using UnityEngine;

public class ItemDropScript : MonoBehaviour
{
    public List<Item> dropItems = new List<Item>(); // List of items that enemy drops

    // Function called to begin dropping items
    public void BeginItemDropping()
    {
        // Go through each droppable item
        for (int i = 0; i < dropItems.Count; i++)
        {
            GameObject item = dropItems[i].itemPrefab; // Current item's prefab
            int dropCount = Random.Range(dropItems[i].minDropCount, dropItems[i].maxDropCount); // Amount of item dropped

            // If drop is not based on chance, drop the item immedietly
            // If is based on chance, drop the item if possible
            if (dropItems[i].noChance == true)
            {
                Drop(item, dropCount);
            }
            else
            {
                float random = Random.Range(0.0f, 100.0f);
                if (dropItems[i].chance >= random) { Drop(item, dropCount); }
            }
        }
    }

    // Function called to drop a given amount of a specified item
    void Drop(GameObject item, int count)
    {
        for (int i = 0; i < count; i++) { Instantiate(item); }
    }
}

[System.Serializable]

// Item Class
public class Item
{
    public GameObject itemPrefab; // Droppable Item's prefab
    [Range(0.0f, 100.0f)] public float chance; // Chance of dropping item, Higher means better chance of dropping
    public bool noChance; // Is item drop decided by chance
    [Range(1, 10)] public int minDropCount; // Minimum amount of possible amount of item dropped
    [Range(1, 10)] public int maxDropCount; // Maximum amount of possible amount of item dropped
}
