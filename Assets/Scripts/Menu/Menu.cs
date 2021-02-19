using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public Camera _cam;
    public LeanTweenType _inAnim, _outAnim;
    public float _transitionDelay;
    public List<GameObject> _interface;
    public float _transitionSpeed;
    public List<Color> _background;
    private int _currentUI;

    private void Awake()
    {
        for (int i = 0; i < _interface.Count; i++) _interface[i].transform.localScale = Vector3.zero;
        LeanTween.scale(_interface[0], Vector3.one, 0.5f).setEase(_inAnim).setDelay(0.5f);
    }
    private void Update()
    {
        if (_cam.backgroundColor != _background[_currentUI]) 
        {
            _cam.backgroundColor = Color.Lerp(_cam.backgroundColor, _background[_currentUI], Time.deltaTime * _transitionSpeed);
        }
    }
    public void NextUIButton(int currentUI)
    {
        LeanTween.scale(_interface[currentUI], Vector3.zero, 0.25f).setEase(_outAnim).setDelay(_transitionDelay);
        LeanTween.scale(_interface[currentUI + 1], Vector3.one, 0.5f).setEase(_inAnim).setDelay(_transitionDelay + 0.5f);
        _currentUI = currentUI + 1;
    }
}