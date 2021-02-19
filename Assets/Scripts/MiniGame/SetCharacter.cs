using UnityEngine;
using TMPro;

public class SetCharacter : MonoBehaviour
{
    public TextMeshProUGUI _userName;
    public TextMeshProUGUI _textArea;

    private void Awake()
    {
        _userName.text = CharacterSelector.userName;
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = CharacterSelector.body;
        transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = CharacterSelector.head;
        transform.localScale = Vector2.zero;
    }
    public void ShowPlayer(string text, float time)
    {
        _textArea.SetText(text);
        LeanTween.scale(gameObject, Vector3.one, 0.5f).setEaseOutBack();
        LeanTween.scale(gameObject, Vector3.zero, 0.5f).setEaseInBack().setDelay(time);
    }
}