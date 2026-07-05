using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // 값 할당은 내부에서만 가능
    public float verticalmove { get; private set; } 
    public float horizontalmove { get; private set; }
    public float verticalrotate { get; private set; } 
    public float horizontalrotate { get; private set; } 
    public bool interact { get; private set; } // 아이템 획득 입력 감지 여부

    private void Update()
    {
        // verticalmove에 관한 입력 감지
        verticalmove = Input.GetAxisRaw("Vertical");
        // horizontalmove에 관한 입력 감지
        horizontalmove = Input.GetAxisRaw("Horizontal");
        // verticalrotate에 관한 입력 감지
        verticalrotate = Input.GetAxis("Mouse Y");
        // horizontalrotate에 관한 입력 감지
        horizontalrotate = Input.GetAxis("Mouse X");
        // getItem에 관한 입력 감지
        interact = Input.GetKeyDown(KeyCode.E);
    }
}