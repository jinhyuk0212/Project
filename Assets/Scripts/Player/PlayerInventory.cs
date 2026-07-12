using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<string> items = new List<string>();

    public void Additem(string item) // 아이템 추가
    {
        items.Add(item);
        Debug.Log($"Added {item} to inventory.");
    }
    
    public bool HasItem(string item) // 아이템 존재 여부 확인
    {
        return items.Contains(item);
    }

    public void RemoveItem(string item) // 아이템 제거
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log($"Removed {item} from inventory.");
        }
    }
}
