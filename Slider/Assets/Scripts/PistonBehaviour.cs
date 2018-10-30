using UnityEngine;
using DG.Tweening;

namespace GameCore {
    public class PistonBehaviour : MonoBehaviour
    {
        [SerializeField]
        GameObject dynamicElement;

        // Use this for initialization
        void Start()
        {

        }

        Tween motionTween;
        private void OnMouseDown()
        {
            if (!motionTween.IsPlaying())
            {
                motionTween = dynamicElement.transform.DOMove(Vector3.one, 0.1f);
                motionTween.OnComplete(() => motionTween.Rewind());
            }
        }
    }
}
