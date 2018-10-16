using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class SliderHead : MonoBehaviour
{
    LineRenderer lineRend;
    CircleCollider2D coll;

    List<SliderPath> tilesChecked = new List<SliderPath>();
    Vector3 lineStartPosition;

    // Use this for initialization
    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        coll = GetComponent<CircleCollider2D>();
    }

    private void LateUpdate()
    {
        if (tilesChecked == null || tilesChecked.Count <= 0)
            return;

        lineRend.positionCount = tilesChecked.Count + 1;
        lineRend.SetPosition(0, tilesChecked[0].GetOriginSideCenter());
        for (int i = 1; i < tilesChecked.Count; i++)
        {
            lineRend.SetPosition(i, tilesChecked[i].transform.position);
        }
        lineRend.SetPosition(lineRend.positionCount -1, transform.position);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        SliderPath sliderP = collision.GetComponent<SliderPath>();
        if (tilesChecked.Contains(sliderP))
            return;

        if(Vector3.Distance(sliderP.transform.position, transform.position) < coll.radius)
        {
            tilesChecked.Add(sliderP);
        }
    }

    private void OnMouseDrag()
    {
        Vector3 flatMousePos = Input.mousePosition;
        flatMousePos.z = transform.position.z;
        Vector3 inputPos = Camera.main.ScreenToWorldPoint(flatMousePos + transform.position);

        float angle = Vector3.Angle(inputPos, tilesChecked.Last().nextPath[0].transform.position);
        Debug.Log(angle);
        Vector3 dir = inputPos * Mathf.Cos(angle);
        Debug.DrawLine(transform.position, dir);

        //if (Vector3.SignedAngle(dir, tilesChecked.Last().nextPath[0].transform.position, Vector3.forward))
            transform.position = Vector3.Lerp(transform.position, dir, 0);
    }
}
