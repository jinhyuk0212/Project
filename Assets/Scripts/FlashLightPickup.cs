using UnityEngine;

public class FlashLightPickup : MonoBehaviour, IInteractable
{
    public void Interact(PlayerInteractor interactor) // 인터렉션 시 호출되는 메서드
    {
        interactor.FlashLight.GetLight(); // 플레이어의 FlashLight 컴포넌트에서 GetLight() 메서드를 호출하여 라이트를 켭니다.
        Destroy(gameObject); // 상호작용 후 플래시라이트 오브젝트를 제거합니다.
    }
}
