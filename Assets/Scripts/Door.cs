using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool open = false; // 문이 열려있는지 여부를 나타내는 변수
    private float doorOpenAngle = 90f; // 문이 열렸을 때 회전 각도
    private float doorCloseAngle = 0f; // 문이 닫혔을 때 회전 각도
    private float smooth = 2f; // 문이 회전하는 속도를 조절하는 변수

    void Update()
    {
        if (open) // 문이 열려있으면 회전 각도를 doorOpenAngle,문이 닫혀있으면 doorCloseAngle로 설정
        {
            Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle, 0); // 회전 각도를 쿼터니언으로 변환
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * smooth);
        }
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(0, doorCloseAngle, 0); // 회전 각도를 쿼터니언으로 변환
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, Time.deltaTime * smooth);
        }
    }
    public void ChangeDoorState() // 문 상태를 바꾸는 함수
    {
        open = !open;
    }
}
