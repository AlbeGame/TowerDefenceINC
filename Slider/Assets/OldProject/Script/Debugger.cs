using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace GameCore
{
    public class Debugger : MonoBehaviour
    {

        List<SliderPath> SliderPathElements = new List<SliderPath>();

        private void OnLevelWasLoaded(int level)
        {
            SliderPathElements = FindObjectsOfType<SliderPath>().ToList();
        }

        private void Start()
        {
        }

        private void OnGUI()
        {
            if (GUI.Button(new Rect(10, 10, 50, 30), "Reset"))
                GameManager.I.LevelMng.ResetLevel();
        }

        private void OnDrawGizmos()
        {
            if (SliderPathElements.Count > 0)
            {
                Gizmos.color = Color.red;
                foreach (SliderPath spElem in SliderPathElements)
                {
                    if (spElem.nextPath.Count > 0)
                        foreach (SliderPath spNext in spElem.nextPath)
                        {
                            Gizmos.DrawLine(spElem.transform.position, spNext.transform.position);
                        }
                }
            }
        }
    }
}
