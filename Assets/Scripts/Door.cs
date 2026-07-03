using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private bool open = false;

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
        ChangeDoorState();
    }
}
