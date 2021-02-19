using UnityEngine;

[CreateAssetMenu(fileName = "New_Question_Data", menuName = "Question Type", order = 1)]
public class TriviaOptions : ScriptableObject
{
    [TextArea]
    public string _question;
    public Sprite[] _anwsers = new Sprite [4];
}