using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<string> items = new List<string>();

    public void Additem(string item)
    {
        items.Add(item);
        Debug.Log($"Added {item} to inventory.");
    }
    
    public bool HasItem(string item)
    {
        return items.Contains(item);
    }

    public void RemoveItem(string item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log($"Removed {item} from inventory.");
        }
    }
}
