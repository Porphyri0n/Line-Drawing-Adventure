using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private Line _linePrefab;
    private Line _currentLine;
    public const float RESOLUTION = 0.001f;
    private bool isInBounds;
    private bool isStillHasTime = true;

    private float drawTime;

    void Start()
    {
        _cam= Camera.main;
        drawTime = PlayerPrefs.GetFloat("DrawTimer");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos =  _cam.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos.y < -4.2f)
        {
            isInBounds = false;
        }
        else
        {
            isInBounds= true;
        }
        if (Input.GetMouseButtonDown(0)&&isInBounds&&isStillHasTime)
        {
            _currentLine = Instantiate(_linePrefab,mousePos,Quaternion.identity);
            StartCoroutine(Counter());
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Destroy(_currentLine.gameObject);
            StopAllCoroutines();
            isStillHasTime= true;
            
        }
        if (Input.GetMouseButton(0)&&isInBounds&&isStillHasTime) {
            _currentLine.SetPosition(mousePos);
            
        }
        
    }
    IEnumerator Counter()
    {
        yield return new WaitForSeconds(drawTime);
        isStillHasTime = false;
    }
}
