using UnityEngine;

[CreateAssetMenu(fileName = "NewMemo", menuName = "Game/Memo Data")] // 코드에 대한 ScriptableObject 생성 메뉴를 추가
public class MemoData : ScriptableObject
{
    [SerializeField] private string memoID; // 메모의 고유 ID를 담는 변수
    [SerializeField] private string title; // 메모의 제목을 담는 변수

    [TextArea(5, 20)]
    [SerializeField] private string content; // 메모의 내용을 담는 변수

    [SerializeField] private Sprite memoImage; // 메모에 첨부된 이미지를 담는 변수

    public string MemoID => memoID;
    public string Title => title;
    public string Content => content;
    public Sprite MemoImage => memoImage;
}