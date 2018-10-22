using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace GameCore
{
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
        Tween forwardTween;
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

            backwardTween.Complete();
            forwardTween = transform.DOMove(transform.position + dir, 5f);
            forwardTween.SetSpeedBased();
        }

        Tween backwardTween;
        private void OnMouseUp()
        {
            MoveBackward();
        }

        private void MoveBackward()
        {
            Vector3[] backPath = new Vector3[tilesChecked.Count];
            for (int i = 0; i < backPath.Length; i++)
            {
                backPath[i] = tilesChecked[i].transform.position;
            }
            backPath = backPath.Reverse().ToArray();

            forwardTween.Kill();
            coll.enabled = false;

            backwardTween = transform.DOPath(backPath, backPath.Length*0.1f);
            backwardTween.SetAutoKill();
            backwardTween.OnWaypointChange((int _wp) =>
            {
                if(tilesChecked.Count > 1)
                {
                    Debug.Log("Moved to: " + backPath[_wp]);
                    tilesChecked.RemoveAt(backPath.Length - 1 - _wp);
                }
            });

            backwardTween.OnKill(() => 
            {
                coll.enabled = true;
            });
        }
    }
}
