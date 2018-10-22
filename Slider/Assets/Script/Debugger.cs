using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace GameCore
{
    public class Debugger : MonoBehaviour
    {

        List<SliderPath> SliderPathElements = new List<SliderPath>();

        private void Start()
        {
            SliderPathElements = FindObjectsOfType<SliderPath>().ToList();
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
