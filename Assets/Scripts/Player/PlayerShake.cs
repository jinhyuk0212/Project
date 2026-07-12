using UnityEngine;

public class PlayerShake : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput; // 플레이어 입력을 받기 위한 PlayerInput 컴포넌트

    [Header("Head Bob")]
    [SerializeField] private float bobSpeed = 8f; // 헤드 밥 속도
    [SerializeField] private float bobAmount = 0.02f; // 헤드 밥 양
    [SerializeField] private float returnSpeed = 8f; // 원래 위치로 돌아가는 속도

    private Vector3 originalPosition;
    private float timer; // 헤드 밥 타이머

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    private void Update()
    {
        bool isMoving = playerInput.horizontalmove != 0 || playerInput.verticalmove != 0; // 움직임 여부 확인

        if (isMoving) // 플레이어가 움직이고 있을 때
        {
            timer += Time.deltaTime * bobSpeed;

            float y = Mathf.Sin(timer) * bobAmount;

            transform.localPosition = originalPosition + new Vector3(0, y, 0f); // 헤드 밥 적용
        }
        else // 플레이어가 움직이지 않고 있을 때
        {
            timer = 0f;

            transform.localPosition = Vector3.Lerp(
                transform.localPosition,
                originalPosition,
                Time.deltaTime * returnSpeed); // 원래 위치로 부드럽게 돌아가기
        }
    }
}