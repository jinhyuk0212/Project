using UnityEngine;

public class CamcorderController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject camcorderObject;

    private bool isRaised = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // 마우스 오른쪽 버튼 클릭 시
        {
            isRaised = !isRaised; // 상태 토글
            animator.SetBool("IsRaised", isRaised); // 애니메이터에 상태 전달
        }
    }

    // Raise 애니메이션 시작 또는 첫 프레임에서 호출
    public void ShowCamcorder() // 애니메이션 이벤트에서 호출
    {
        camcorderObject.SetActive(true);
    }

    // Lower 애니메이션 마지막 프레임에서 호출
    public void HideCamcorder()
    {
        camcorderObject.SetActive(false);
    }
}