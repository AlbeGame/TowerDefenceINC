using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace GameCore
{
    public class SliderHead : MonoBehaviour
    {
        CapsuleCollider coll;

        List<SliderPath> tilesChecked = new List<SliderPath>();

        // Use this for initialization
        void Awake()
        {
            coll = GetComponent<CapsuleCollider>();
        }

        //Evaluate current tile
        private void OnTriggerStay(Collider collision)
        {
            SliderPath sliderP = collision.GetComponent<SliderPath>();
            if (tilesChecked.Contains(sliderP))
                return;

            if (Vector3.Distance(sliderP.transform.position, transform.position) < coll.radius)
            {
                tilesChecked.Add(sliderP);
                sliderP.MarkAsPassed(true);
                if(sliderP.NextLevel > -1)
                {
                    GameManager.I.ChangeLevel(sliderP.NextLevel);
                }
            }
        }

        //Trigger the forward movement
        private void OnMouseDrag()
        {
            MoveForward();
        }

        //Trigger the backward movement
        private void OnMouseUp()
        {
            MoveBackward();
        }

        Tween forwardTween;
        /// <summary>
        /// Manage the forward movement
        /// </summary>
        private void MoveForward()
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
        /// <summary>
        /// Manage the backward movement
        /// </summary>
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
                    SliderPath tile = tilesChecked[backPath.Length - 1 - _wp];
                    tile.MarkAsPassed(false);
                    tilesChecked.Remove(tile);
                }
            });

            backwardTween.OnKill(() => 
            {
                coll.enabled = true;
            });
        }
    }
}
