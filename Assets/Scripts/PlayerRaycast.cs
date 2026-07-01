using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    private RaycastHit hit; //ray의 충돌 정보를 담는 변수
    private Ray ray; //ray를 담는 변수

    private PlayerInput playerinput;
    private FlashLight flashlight;

    private void Start()
    {
        playerinput = GetComponent<PlayerInput>();
        flashlight = GetComponentInChildren<FlashLight>();
    }
    private void Update()
    {
        if (playerinput.interact) //아이템 획득 입력이 들어왔는지 확인
        {
            ObjectHit(); //아이템 획득 입력이 들어오면 ObjectHit() 함수 호출
            Debug.Log("Interact Input Detected"); //디버그 로그 출력")
        }
    }

    private void ObjectHit()
    {
        ray = new Ray(transform.position, transform.forward); //ray 생성
        if (Physics.Raycast(ray, out hit, 30f)) //raycast를 쏘고 충돌 정보가 hit에 담김
        {
            if (hit.collider.CompareTag("FlashLight"))
            {
                Debug.Log("FlashLight Get!"); //디버그 로그 출력
                flashlight.GetLight(); //FlashLight 스크립트의 GetLight() 함수 호출
            }
        }
    }
}
