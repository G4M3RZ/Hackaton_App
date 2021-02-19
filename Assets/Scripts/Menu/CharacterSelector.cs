using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelector : MonoBehaviour
{
    [Serializable] public struct Body
    {
        public string bodyPartName;
        public int currentSelect;
        public List<Sprite> options;
    }

    public GameObject fade;
    [SerializeField] Body[] Elements;
    public TMP_InputField _field;

    static public string userName;
    static public Sprite head;
    static public Sprite body;

    public void Next(int bodyPart)
    {
        if (Elements[bodyPart].currentSelect < Elements[bodyPart].options.Count - 1)
        {
            Elements[bodyPart].currentSelect++;
            transform.GetChild(bodyPart).GetChild(0).GetChild(0).GetComponent<Image>().sprite =
                Elements[bodyPart].options[Elements[bodyPart].currentSelect];
        }
    }
    public void Previous(int bodyPart)
    {
        if (Elements[bodyPart].currentSelect > 0)
        {
            Elements[bodyPart].currentSelect--;
            transform.GetChild(bodyPart).GetChild(0).GetChild(0).GetComponent<Image>().sprite =
                Elements[bodyPart].options[Elements[bodyPart].currentSelect];
        }
    }
    public void SaveButton(string sceneName)
    {
        userName = _field.text;
        head = Elements[0].options[Elements[0].currentSelect];
        body = Elements[1].options[Elements[1].currentSelect];
        Instantiate(fade, transform.parent).GetComponent<Fade_Controller>()._sceneName = sceneName;
    }
}