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
    [SerializeField] private GameObject[] nightVisionObjects; // 나이트비전일 때만 보일 오브젝트들
    [SerializeField] private UIManager uiManager; // UIManager 컴포넌트를 담는 변수

    private FilmGrain filmGrain; // 포스트 프로세싱 효과: 필름 그레인
    private Vignette vignette; // 포스트 프로세싱 효과: 비네팅
    private ColorAdjustments colorAdjustments; // 포스트 프로세싱 효과: 색상 조정
    
    private float normalFOV = 50f; 
    private float camcorderFOV = 50f;
    private float maxEnergy = 100f;     // 나이트 비전 모드 최대 에너지
    private float minUseEnergy = 10f;   // 나이트 비전 모드 최소 사용 가능 에너지
    private float drainSpeed = 10f;     // 켰을 때 초당 소모량
    private float rechargeSpeed = 5f;   // 껐을 때 초당 회복량

    private float currentEnergy;        // 현재 에너지
    private bool isRaised = false; // 캠코더가 들어올려진 상태인지 여부
    private bool isNightVision = false; // 나이트 비전 모드 활성화 여부
    private bool isAnimating = false; // 애니메이션 진행 중인지 여부

    private void Awake()
    {
        volume.profile.TryGet(out filmGrain);
        volume.profile.TryGet(out vignette);
        volume.profile.TryGet(out colorAdjustments);

        SetNightVision(false);
    }

    private void Update()
    {
        HandleCamcorderInput();// 캠코더 입력 처리
        HandleNightVisionInput(); // 나이트 비전 입력 처리
        HandleNightVisionEnergy(); // 나이트 비전 에너지 처리
    }

    // 마우스 오른쪽 버튼 입력 시 캠코더 들어올리기/내리기 토글
    private void HandleCamcorderInput() 
    {
        if (!isAnimating && Input.GetMouseButtonDown(1)) 
        {
            isAnimating = true;

            isRaised = !isRaised;
            animator.SetBool("IsRaised", isRaised);

            if (!isRaised)
                SetNightVision(false);
        }
    }
    // N 키 입력 시 나이트 비전 모드 토글, 캠코더가 들어올려진 상태에서만 가능
    private void HandleNightVisionInput()
    {
        if (Input.GetKeyDown(KeyCode.N) && isRaised) // N 키 입력 시 나이트 비전 모드 토글, 캠코더가 들어올려진 상태에서만 가능
        {
            if (isNightVision)
            {
                SetNightVision(false);
            }
            else if (currentEnergy >= minUseEnergy)
            {
                SetNightVision(true);
            }
        }
    }

    // 나이트 비전 모드일 때 에너지 감소, 아닐 때 에너지 회복
    private void HandleNightVisionEnergy()
    {
        if (isNightVision)
        {
            currentEnergy -= drainSpeed * Time.deltaTime;

            if (currentEnergy <= 0f)
            {
                currentEnergy = 0f;
                SetNightVision(false);
            }
        }
        else
        {
            currentEnergy += rechargeSpeed * Time.deltaTime;
            currentEnergy = Mathf.Clamp(currentEnergy, 0f, maxEnergy);
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
        isAnimating = false;
    }

    public void SetCamcorder() // 카메라를 캠코더 모드로 설정
    {
        playerCamera.Lens.FieldOfView = camcorderFOV;
        UIManager.Instance.ShowCamcorderUI(true); // 캠코더 UI 표시

        if (filmGrain != null)
            filmGrain.intensity.value = 1.0f;

        if (vignette != null)
            vignette.intensity.value = 0.5f;
    }

    public void SetNormal() // 카메라 원래 상태로 되돌리기
    {
        playerCamera.Lens.FieldOfView = normalFOV;
        UIManager.Instance.ShowCamcorderUI(false); // 캠코더 UI 숨기기

        if (filmGrain != null)
            filmGrain.intensity.value = 0f;

        if (vignette != null)
            vignette.intensity.value = 0.1f;
    }

    private void SetNightVision(bool value) // 나이트 비전 모드 설정
    {
        isNightVision = value; // 나이트 비전 모드 상태 업데이트

        if (nightVisionLight != null) // 나이트 비전 라이트 활성화/비활성화
            nightVisionLight.enabled = value;

        foreach (GameObject obj in nightVisionObjects) // 나이트 비전 모드일 때만 보일 오브젝트 활성화/비활성화
        {
            if (obj != null)
                obj.SetActive(value);
        }

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
            vignette.intensity.value = value ? 0.3f : (isRaised ? 0.3f : 0.1f); // 나이트 비전 모드일 때 비네팅 강도 설정
    }
}