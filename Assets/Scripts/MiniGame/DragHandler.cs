using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Range(0, 5)] 
    public int answer;
    public GameObject line;
    private Camera _cam;
    private GameObject currentLine;
    private Vector2 startPos;

    private void Awake()
    {
        _cam = Camera.main;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (transform.childCount == 0) 
            currentLine = Instantiate(line, transform);
        else
        {
            Destroy(currentLine);
            currentLine = Instantiate(line, transform);
        }
        startPos = currentLine.transform.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        RectTransform rect = currentLine.GetComponent<RectTransform>();
        Vector2 currentPoint = (Vector2)_cam.ScreenToWorldPoint(Input.mousePosition);

        float distance = Vector2.Distance(startPos, currentPoint);
        rect.sizeDelta = new Vector2(distance * 200, 15);

        float angle = Mathf.Atan2(startPos.y - currentPoint.y, startPos.x - currentPoint.x) * Mathf.Rad2Deg;
        currentLine.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        RaycastHit2D hit = Physics2D.Raycast(_cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            GetComponentInParent<Lines>().value[answer] = 
                (answer == hit.collider.GetComponent<AnswersNum>().answer) ? true : false;

            float distance = Vector2.Distance(startPos, hit.transform.position) - 0.1f;
            currentLine.GetComponent<RectTransform>().sizeDelta = new Vector2(distance * 200, 15);

            float angle = Mathf.Atan2(startPos.y - hit.transform.position.y, 
                startPos.x - hit.transform.position.x) * Mathf.Rad2Deg;
            currentLine.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        }
        else
        {
            Destroy(currentLine);
        }
    }
}