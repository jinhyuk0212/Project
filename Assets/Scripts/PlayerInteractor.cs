using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private RaycastHit hit; //ray의 충돌 정보를 담는 변수
    private Ray ray; //ray를 담는 변수
    private FlashLight flashLight; // FlashLight 컴포넌트를 담는 변수
    private PlayerInput playerinput; // PlayerInput 컴포넌트를 담는 변수
    public FlashLight FlashLight => flashLight; // FlashLight 컴포넌트에 대한 public getter

    private void Start()
    {
        playerinput = GetComponent<PlayerInput>();
        flashLight = GetComponentInChildren<FlashLight>(); 
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
            IInteractable interactable = hit.collider.GetComponent<IInteractable>(); //충돌한 오브젝트에 IInteractable 인터페이스가 있는지 확인

            if (interactable != null)
            {
                interactable.Interact(this);
            }
        }
    }
}
