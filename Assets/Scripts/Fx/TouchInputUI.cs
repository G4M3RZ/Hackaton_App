using UnityEngine;
using TMPro;

public class TouchInputUI : MonoBehaviour
{
    public AnimationCurve _animationCurve;
    
    private TextMeshProUGUI _text;
    private Color _textColor;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, 0);
        _textColor = _text.color;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && transform.parent.localScale == Vector3.one)
        {
            GetComponentInParent<Menu>().NextUIButton(1);
            Destroy(this.gameObject);
        } 
        else
        {
            _textColor.a = _animationCurve.Evaluate(Mathf.PingPong(Time.time, 1));
            _text.color = _textColor;
        }
    }
}