using UnityEngine;

public class Memo : MonoBehaviour, IInteractable
{
    [SerializeField] private MemoData memoData;


    private void Start()
    {
    }

    public void Interact(PlayerInteractor interactor)
    {
        if (memoData == null)
        {
            Debug.LogWarning($"{gameObject.name}에 MemoData가 없습니다.");
            return;
        }


        UIManager.Instance.MemoUI.OpenMemo(memoData);
    }
}