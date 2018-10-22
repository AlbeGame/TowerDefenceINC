using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class SliderHead : MonoBehaviour
{
    LineRenderer lineRend;
    CapsuleCollider coll;

    List<SliderPath> tilesChecked = new List<SliderPath>();
    Vector3 lineStartPosition;

    // Use this for initialization
    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        coll = GetComponent<CapsuleCollider>();
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
        lineRend.SetPosition(lineRend.positionCount - 1, transform.position);
    }

    private void OnTriggerStay(Collider collision)
    {
        SliderPath sliderP = collision.GetComponent<SliderPath>();
        if (tilesChecked.Contains(sliderP))
            return;

        if (Vector3.Distance(sliderP.transform.position, transform.position) < coll.radius)
        {
            tilesChecked.Add(sliderP);
        }
    }

    private void OnMouseDrag()
    {
        Vector3 inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        inputPos.z = transform.position.z;
        inputPos = inputPos - transform.position;

        Vector3 pathDir = tilesChecked.Last().nextPath[0].transform.position - transform.position;
        Vector3 dir = Vector3.Project(inputPos, pathDir);
        if (Vector3.Angle(dir, pathDir) > 0)
        {
            dir = Vector3.zero;
        }

        transform.position = Vector3.Lerp(transform.position, transform.position + dir, 0.5f);
    }
}
