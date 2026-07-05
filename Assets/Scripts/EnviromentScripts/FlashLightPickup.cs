using UnityEngine;

public class FlashLightPickup : MonoBehaviour, IInteractable
{
    private string itemname = "FlashLight"; // 플래시라이트 이름
    public void Interact(PlayerInteractor interactor) // 인터렉션 시 호출되는 메서드
    {
        interactor.Inventory.Additem(itemname); // 플레이어 인벤토리에 플래시라이트를 추가합니다.
        Destroy(gameObject); // 상호작용 후 플래시라이트 오브젝트를 제거합니다.
    }
}
