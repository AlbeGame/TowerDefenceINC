
using UnityEngine;

namespace GameCore
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private SliderHead sliderH;
        private SliderHead sliderH_I;

        private SliderPath sliderP_Start;

        // Use this for initialization
        void Start()
        {

        }

        void DeploySliderHead()
        {
            if (sliderH != null && sliderH_I == null)
                sliderH_I = Instantiate<SliderHead>(sliderH);
        }
    }
}
