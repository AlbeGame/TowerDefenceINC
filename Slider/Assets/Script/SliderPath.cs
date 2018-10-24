using UnityEngine;
using System.Collections.Generic;

namespace GameCore
{
    public class SliderPath : MonoBehaviour
    {
        #region Level datas
        public OriginSide StartingSide;
        public int NextLevel = -1;
        #endregion

        public List<SliderPath> nextPath = new List<SliderPath>();
        BoxCollider coll;
        MeshRenderer mRenderer;

        private void Start()
        {
            coll = GetComponent<BoxCollider>();
            mRenderer = GetComponent<MeshRenderer>();
        }

        public void MarkAsPassed(bool _passed)
        {
            if (_passed)
                mRenderer.material.color = Color.grey;
            else
                mRenderer.material.color = Color.white;
        }

        #region Edge management (not used)
        public Vector3 GetOriginSideCenter()
        {
            switch (StartingSide)
            {
                case OriginSide.None:
                    return transform.position;
                case OriginSide.Left:
                    return transform.position + (Vector3.left * coll.size.x) / 2;
                case OriginSide.Top:
                    return transform.position + (Vector3.up * coll.size.y) / 2;
                case OriginSide.Bottom:
                    return transform.position + (Vector3.down * coll.size.y) / 2;
                case OriginSide.Right:
                    return transform.position + (Vector3.right * coll.size.x) / 2;
                default:
                    break;
            }

            //default exit
            return transform.position;
        }

        public enum OriginSide { None, Left, Top, Bottom, Right }
        #endregion
    }
}
