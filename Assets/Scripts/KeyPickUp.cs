using UnityEngine;

public class KeyPickUp : MonoBehaviour, IInteractable
{
    [SerializeField] private string Keyname = "Key"; // 열쇠 이름
    public void Interact(PlayerInteractor interactor)
    {
        interactor.Inventory.Additem(Keyname); // 플레이어 인벤토리에 열쇠 추가

        Destroy(gameObject); // 열쇠 오브젝트 제거
    }
}

