using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MemoUI : MonoBehaviour
{
    [Header("Memo UI")]
    [SerializeField] private GameObject memoPanel; // 메모 UI 패널
    [SerializeField] private TMP_Text titleText; // 메모 제목 텍스트
    [SerializeField] private TMP_Text contentText; // 메모 내용 텍스트
    [SerializeField] private Image memoImage; // 메모 이미지

    public bool IsOpen { get; private set; }

    private void Start()
    {
        memoPanel.SetActive(false);
    }

    private void Update()
    {
        if (!IsOpen)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseMemo();
        }
    }

    public void OpenMemo(MemoData memoData)
    {
        if (memoData == null)
            return;

        IsOpen = true;
        memoPanel.SetActive(true);

        titleText.text = memoData.Title;
        contentText.text = memoData.Content;

        if (memoData.MemoImage != null)
        {
            memoImage.gameObject.SetActive(true);
            memoImage.sprite = memoData.MemoImage;
        }
        else
        {
            memoImage.gameObject.SetActive(false);
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }

    public void CloseMemo()
    {
        IsOpen = false;
        memoPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1f;
    }
}