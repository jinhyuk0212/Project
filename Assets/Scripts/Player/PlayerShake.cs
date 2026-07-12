using UnityEngine;

public class HeadBob : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;

    [Header("Head Bob")]
    [SerializeField] private float bobSpeed = 8f;
    [SerializeField] private float bobAmount = 0.02f;
    [SerializeField] private float returnSpeed = 8f;

    private Vector3 originalPosition;
    private float timer;

    private void Start()
    {
        originalPosition = transform.localPosition;

        if (playerInput == null)
            playerInput = GetComponentInParent<PlayerInput>();
    }

    private void Update()
    {
        bool isMoving =
            Mathf.Abs(playerInput.horizontalmove) > 0.01f ||
            Mathf.Abs(playerInput.verticalmove) > 0.01f;

        if (isMoving)
        {
            timer += Time.deltaTime * bobSpeed;

            float y = Mathf.Sin(timer) * bobAmount;

            transform.localPosition = originalPosition + new Vector3(0, y, 0f);
        }
        else
        {
            timer = 0f;

            transform.localPosition = Vector3.Lerp(
                transform.localPosition,
                originalPosition,
                Time.deltaTime * returnSpeed);
        }
    }
}