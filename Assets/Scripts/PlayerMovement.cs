using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; //이동속도
    public float rotateSpeed = 5f; //회전속도
    public float gravity = 10;
    private Vector3 moveDirection;
    private float mouseX;

    private PlayerInput playerInput;
    private Animator playerAnimator;
    private CharacterController playerController;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerController = GetComponent<CharacterController>();
        playerAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate() //물리기반 업데이트
    {
        Rotate();
        Move();
    }
    private void Move()
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

        playerController.Move(moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    private void Rotate()
    {
        mouseX += playerInput.horizontalrotate * rotateSpeed;
        transform.localRotation = Quaternion.Euler(0, mouseX, 0);
    }
}