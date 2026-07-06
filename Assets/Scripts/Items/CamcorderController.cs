using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CamcorderController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject camcorderObject;
    [SerializeField] private CinemachineCamera playerCamera;
    [SerializeField] private Volume volume;

    private FilmGrain filmGrain;
    private Vignette vignette;

    private float normalFOV = 50f;
    private float camcorderFOV = 40f;

    private bool isRaised = false;

    private void Awake()
    {
        volume.profile.TryGet(out filmGrain);
        volume.profile.TryGet(out vignette);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRaised = !isRaised;
            animator.SetBool("IsRaised", isRaised);
        }
    }

    // Raise 애니메이션 시작
    public void ShowCamcorder()
    {
        camcorderObject.SetActive(true);
    }

    // Lower 애니메이션 끝
    public void HideCamcorder()
    {
        camcorderObject.SetActive(false);
    }

    // Raise 애니메이션 마지막 프레임
    public void SetCamcorderFOV()
    {
        playerCamera.Lens.FieldOfView = camcorderFOV;

        if (filmGrain != null)
            filmGrain.intensity.value = 0.7f;

        if (vignette != null)
            vignette.intensity.value = 0.5f;
    }

    // Lower 애니메이션 마지막 프레임
    public void SetNormalFOV()
    {
        playerCamera.Lens.FieldOfView = normalFOV;

        if (filmGrain != null)
            filmGrain.intensity.value = 0f;

        if (vignette != null)
            vignette.intensity.value = 0.2f;
    }
}