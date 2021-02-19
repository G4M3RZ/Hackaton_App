using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Trivia : MonoBehaviour
{
    public TextMeshProUGUI _tittle;
    public List<Image> _buttons;

    public List<TriviaOptions> _trivias;
    public SetCharacter _ch;

    private void Awake()
    {
        if (_trivias.Count == 0) return;
        int random = Random.Range(0, _trivias.Count);
        TriviaOptions trivia = _trivias[random];

        _tittle.SetText(trivia._question);
        for (int i = 0; i < trivia._anwsers.Length; i++) 
            _buttons[i].sprite = trivia._anwsers[i];
    }
    public void AnswerButton(bool isTrue)
    {
        string message = (isTrue) ? "Good Job" : "Wrong Answer";
        _ch.ShowPlayer(message, 2.5f);
        GetComponentInParent<Menu>().NextUIButton(0);
    }
}