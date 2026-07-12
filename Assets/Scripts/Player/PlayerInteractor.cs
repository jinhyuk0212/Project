using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private RaycastHit hit; //ray의 충돌 정보를 담는 변수
    private Ray ray; //ray를 담는 변수

    [SerializeField] private PlayerInput playerinput; // PlayerInput 컴포넌트를 담는 변수
    [SerializeField] private PlayerInventory inventory; // PlayerInventory 컴포넌트를 담는 변수
    [SerializeField] private UIManager uiManager; // UIManager 컴포넌트를 담는 변수
    [SerializeField] private Transform cameraTransform; // 카메라 Transform을 담는 변수

    private IInteractable currentInteractable; // 현재 상호작용 가능한 오브젝트를 담는 변수
    public PlayerInventory Inventory => inventory; // PlayerInventory 컴포넌트에 대한 public getter

    private void Update()
    {
        CheckInteractable(); // 매 프레임 바라보는 대상 체크

        if (playerinput.interact && currentInteractable != null) // 상호작용 입력이 들어왔고, 현재 상호작용 가능한 오브젝트가 존재하면
        {
            currentInteractable.Interact(this); // 상호작용 실행
            Debug.Log("Interact Input Detected");
        }
    }

    private void CheckInteractable() // 플레이어가 바라보는 대상이 상호작용 가능한 오브젝트인지 체크
    {
        ray = new Ray(cameraTransform.position, cameraTransform.forward);

        if (Physics.Raycast(ray, out hit, 1.5f))
        {
            currentInteractable = hit.collider.GetComponent<IInteractable>();

            if (currentInteractable != null)
            {
                uiManager.SetCrosshairInteract(); // 상호작용 가능한 오브젝트를 바라보고 있을 때 크로스헤어 변경
                uiManager.ShowInteractText("Interact"); // 상호작용 가능한 오브젝트를 바라보고 있을 때 상호작용 텍스트 표시
                return;
            }
        }

        currentInteractable = null; // 상호작용 가능한 오브젝트가 없을 때 currentInteractable을 null로 설정
        uiManager.SetCrosshairNormal(); // 상호작용 가능한 오브젝트를 바라보고 있지 않을 때 크로스헤어 원래대로 변경
        uiManager.HideInteractText(); // 상호작용 가능한 오브젝트를 바라보고 있지 않을 때 상호작용 텍스트 숨김
    }
}
