
using UnityEngine;

namespace GameCore
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager I { get; private set; }

        [SerializeField]
        private SliderHead sliderH;
        private SliderHead sliderH_I;

        private SliderPath sliderP_Start;

        private void Awake()
        {
            //--Singleton--
            if (I != null)
                DestroyImmediate(gameObject);
            else
            {
                I = this;
                DontDestroyOnLoad(gameObject);
            }
            //-------------
        }

        void DeploySliderHead()
        {
            if (sliderH != null && sliderH_I == null)
                sliderH_I = Instantiate<SliderHead>(sliderH,sliderP_Start.transform.position, sliderP_Start.transform.rotation);
        }
    }
}
