using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string requ; // 문을 열기 위해 필요한 아이템 이름
    private bool open = false; // 문 열림 상태
    private bool isUnlocked = false; // 문 잠금 상태
    private float doorOpenAngle = 90f;
    private float doorCloseAngle = 0f;
    private float smooth = 2f;

    private Quaternion targetRotation;

    private void Start() // 초기 회전값 설정
    {
        targetRotation = Quaternion.Euler(0, doorCloseAngle, 0);
    }

    private void Update() // 문 회전
    {
        transform.localRotation = Quaternion.Slerp(
            transform.localRotation,
            targetRotation,
            Time.deltaTime * smooth); // Slerp를 사용하여 부드럽게 회전
    }

    private void ChangeDoorState() // 문 열기/닫기 상태 변경
    {
        open = !open;

        float angle = open ? doorOpenAngle : doorCloseAngle;

        targetRotation = Quaternion.Euler(0, angle, 0);
    }

    public void Interact(PlayerInteractor interactor) // IInteractable 인터페이스 구현
    {
        if (isUnlocked == false)
        {
            if (interactor.Inventory.HasItem(requ) == false)
            {
                Debug.Log("문을 열기 위해 필요한 아이템이 없습니다.");
                return;
            }
            interactor.Inventory.RemoveItem(requ);
            isUnlocked = true;
        }
        ChangeDoorState();
    }
}
