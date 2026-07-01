using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private bool useLight = false;
    private Light myLight;

    private void Start()
    {
        myLight = GetComponent<Light>();
        myLight.enabled = false;
    }

    private void Update()
    {
        if (useLight && Input.GetKeyDown(KeyCode.F))
        {
            myLight.enabled = !myLight.enabled;
        }
    }

    public void GetLight()
    {
        useLight = true;
    }
}