using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f; //이동속도
    public float rotateSpeed = 3f; //회전속도
    public float gravity = 10; //중력
    public Transform head; //머리
    private Vector3 moveDirection; //이동방향
    private float mouseX, mouseY; //마우스 좌우, 상하 회전값

    private PlayerInput playerInput; //플레이어 입력
    private Animator playerAnimator; //플레이어 애니메이터
    private CharacterController playerController; //플레이어 캐릭터 컨트롤러

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        playerInput = GetComponent<PlayerInput>();
        playerController = GetComponent<CharacterController>();
        playerAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate() //물리기반 업데이트
    {
        Rotate();
        Move();
    }
    private void Move() //이동
    {
        if (playerController.isGrounded) //땅에 닿아있으면
        {
            moveDirection = new Vector3(playerInput.horizontalmove, 0, playerInput.verticalmove);
            moveDirection = playerController.transform.TransformDirection(moveDirection); // 로컬좌표를 월드좌표로 변환
        }
        else //땅에 닿아있지 않으면
        {
            moveDirection.y -= gravity * Time.fixedDeltaTime;
        }

        playerController.Move(moveDirection * moveSpeed * Time.fixedDeltaTime); // 월드좌표로 변환된 이동방향에 이동속도와 프레임시간을 곱하여 이동
    }

    private void Rotate() //회전
    {
        mouseX += playerInput.horizontalrotate * rotateSpeed;
        mouseY += playerInput.verticalrotate * rotateSpeed;

        mouseY = Mathf.Clamp(mouseY, -60f, 40f); // 상하 회전 제한

        transform.localRotation = Quaternion.Euler(0, mouseX, 0); //몸 (좌우회전)
        head.localRotation = Quaternion.Euler(-mouseY, 0, 0); //머리 (상하회전) // 월드좌표로 변환된 이동방향에 이동속도와 프레임시간을 곱하여 이동
    }
}