using UnityEngine;

public class ObjectPoint : MonoBehaviour
{
    public GameObject flashLight;
    private void Awake()
    {
        FlashMake();
    }
    private void FlashMake()
    {
        Instantiate(flashLight, transform.position, transform.rotation);
    }
}
