using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CamcorderController : MonoBehaviour
{
    [SerializeField] private Animator animator; // 애니메이션 컨트롤러
    [SerializeField] private GameObject camcorderObject; // 캠코더 오브젝트
    [SerializeField] private CinemachineCamera playerCamera; // 플레이어 카메라
    [SerializeField] private Volume volume; // 포스트 프로세싱 볼륨
    [SerializeField] private Light nightVisionLight; // 나이트 비전용 라이트

    private FilmGrain filmGrain; // 포스트 프로세싱 효과: 필름 그레인
    private Vignette vignette; // 포스트 프로세싱 효과: 비네팅
    private ColorAdjustments colorAdjustments; // 포스트 프로세싱 효과: 색상 조정

    private float normalFOV = 50f; 
    private float camcorderFOV = 50f;

    private bool isRaised = false; // 캠코더가 들어올려진 상태인지 여부
    private bool isNightVision = false; // 나이트 비전 모드 활성화 여부

    private void Awake()
    {
        volume.profile.TryGet(out filmGrain);
        volume.profile.TryGet(out vignette);
        volume.profile.TryGet(out colorAdjustments);

        SetNightVision(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) // 마우스 오른쪽 버튼 클릭 시 캠코더 들어올리기/내리기
        {
            isRaised = !isRaised;
            animator.SetBool("IsRaised", isRaised);

            if (!isRaised) // 캠코더를 내릴 때 나이트 비전 모드 해제
                SetNightVision(false);
        }

        if (Input.GetKeyDown(KeyCode.N) && isRaised) // N 키를 눌러 나이트 비전 모드 토글
        {
            SetNightVision(!isNightVision);
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

    public void SetCamcorder() // 카메라를 캠코더 모드로 설정
    {
        playerCamera.Lens.FieldOfView = camcorderFOV;

        if (filmGrain != null)
            filmGrain.intensity.value = 1.0f;

        if (vignette != null)
            vignette.intensity.value = 0.6f;
    }

    public void SetNormal() // 카메라 원래 상태로 되돌리기
    {
        playerCamera.Lens.FieldOfView = normalFOV;

        if (filmGrain != null)
            filmGrain.intensity.value = 0f;

        if (vignette != null)
            vignette.intensity.value = 0.2f;
    }

    private void SetNightVision(bool value) // 나이트 비전 모드 설정
    {
        isNightVision = value; // 나이트 비전 모드 상태 업데이트

        if (nightVisionLight != null) // 나이트 비전 라이트 활성화/비활성화
            nightVisionLight.enabled = value;

        if (colorAdjustments != null) // 색상 조정 효과 적용
        {
            colorAdjustments.colorFilter.value = value ? Color.green : Color.white;
            colorAdjustments.postExposure.value = value ? 0.3f : 0f;
            colorAdjustments.saturation.value = value ? -40f : 0f;
            colorAdjustments.contrast.value = value ? 30f : 0f;
        }

        if (filmGrain != null)
            filmGrain.intensity.value = value ? 1.0f : (isRaised ? 1.0f : 0f); // 나이트 비전 모드일 때 필름 그레인 강도 설정

        if (vignette != null)
            vignette.intensity.value = value ? 0.7f : (isRaised ? 0.6f : 0.2f); // 나이트 비전 모드일 때 비네팅 강도 설정
    }
}