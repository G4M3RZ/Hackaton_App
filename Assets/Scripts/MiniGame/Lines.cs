using System.Collections.Generic;
using UnityEngine;

public class Lines : MonoBehaviour
{
    public List<bool> value;
    public List<string> _goodText, _badText;
    public SetCharacter _ch;

    public void CheckButton()
    {
        int goodCount = 0;
        for (int i = 0; i < value.Count; i++) if (value[i]) goodCount++;

        if(goodCount > 2)
        {
            int random = Random.Range(0, _goodText.Count);
            _ch.ShowPlayer(_goodText[random], 5f);
        }
        else
        {
            int random = Random.Range(0, _badText.Count);
            _ch.ShowPlayer(_badText[random], 3f);
        }
    }
}