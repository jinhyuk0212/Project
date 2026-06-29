using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; //이동속도
    public float rotateSpeed = 5f; //회전속도

    private PlayerInput playerInput;
    private Rigidbody playerRigidbody;
    private Animator playerAnimator;
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate() //물리기반 업데이트
    {
        Rotate();
        Move();
    }
    private void Move()
    {
        Vector3 moveDirection 
            = new Vector3(playerInput.horizontalmove, 0, playerInput.verticalmove);

        moveDirection = moveDirection.normalized; // 이동 방향 벡터를 정규화하여 속도에 영향을 주지 않도록 함

        playerRigidbody.MovePosition(playerRigidbody.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    private void Rotate()
    {
    }
}
