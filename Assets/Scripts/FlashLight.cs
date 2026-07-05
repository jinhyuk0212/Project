using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private string requiredItemName = "FlashLight"; // 손전등을 켜기 위해 필요한 아이템 이름

    private Light myLight; // 손전등의 Light 컴포넌트
    private PlayerInventory inventory; // 플레이어의 인벤토리 참조

    private void Start() // 초기화
    {
        myLight = GetComponent<Light>();
        inventory = GetComponentInParent<PlayerInventory>();

        myLight.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // F 키를 눌렀을 때
        {
            if (inventory.HasItem(requiredItemName) == false) // 플레이어가 손전등을 가지고 있지 않다면
            {
                Debug.Log("손전등이 없음");
                return;
            }

            myLight.enabled = !myLight.enabled; // 손전등 켜기/끄기
        }
    }
}