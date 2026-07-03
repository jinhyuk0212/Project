using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private bool hseLight = false; // 불빛 사용 여부를 나타내는 변수
    private Light myLight; // Light 컴포넌트를 담는 변수

    private void Start()
    {
        myLight = GetComponent<Light>(); // Light 컴포넌트 가져오기 
        myLight.enabled = false; // Light 컴포넌트 비활성화
    }

    private void Update()
    {
        if (hseLight && Input.GetKeyDown(KeyCode.F)) // 불빛 사용 여부가 true이고 F키를 눌렀을 때
        {
            myLight.enabled = !myLight.enabled; // Light 컴포넌트 활성화/비활성화 토글
        }
    }

    public void GetLight() // 불빛 사용 여부를 true로 설정하는 함수
    {
        hseLight = true; // 불빛 사용 여부를 true로 설정
        Debug.Log("Flashlight acquired!"); // 디버그 로그 출력
    }                                                                                                                                                               
}