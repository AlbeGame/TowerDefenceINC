using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class SliderHead : MonoBehaviour {

    LineRenderer lineRend;
    Vector3 lineStartPosition;

	// Use this for initialization
	void Start () {
        lineRend = GetComponent<LineRenderer>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SliderPath sliderP = collision.GetComponent<SliderPath>();
        if(sliderP != null)
        {
            lineStartPosition = sliderP.GetOriginSideCenter();
            lineRend.SetPosition(0, lineStartPosition);
            lineRend.SetPosition(1, transform.position);
        }
    }
}
