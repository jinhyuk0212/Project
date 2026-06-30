using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private bool playerGetLight = false; //true일 경우 손전등 on
    private Light myLight; // light 컴포너트를 담는 변수
    void Start()
    {
        myLight = GetComponent<Light>(); //오브젝트가 가진 light 컴포넌트를 가져옴
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // R키를 누르면 손전등 on/off
        {
            playerGetLight = playerGetLight ? false : true;
        }

        if (playerGetLight == false) 
        {
            myLight.enabled = false;
        }

        if (playerGetLight == true)
        {
            myLight.enabled = true;
        }
    }
}
