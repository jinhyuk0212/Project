using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string verticalAxisName = "Vertical"; // 앞뒤 움직임을 위한 입력축 이름
    public string horizontalAxisName = "Horizontal"; // 좌우 움직임을 위한 입력축 이름
    public string rotateAxisName = "Mouse X"; // 좌우 회전을 위한 입력축 이름

    // 값 할당은 내부에서만 가능
    public float verticalmove { get; private set; } 
    public float horizontalmove { get; private set; }
    public float rotate { get; private set; } 
    
    private void Update()
    {
        // verticalmove에 관한 입력 감지
        verticalmove = Input.GetAxisRaw(verticalAxisName);
        // horizontalmove에 관한 입력 감지
        horizontalmove = Input.GetAxisRaw(horizontalAxisName);
        // rotate에 관한 입력 감지
        rotate = Input.GetAxisRaw(rotateAxisName);
    }
}