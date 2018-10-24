
using UnityEngine;

namespace GameCore
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager I { get; private set; }

        [SerializeField]
        private SliderHead sliderH_prefab;
        private SliderHead sliderH_I;
        [SerializeField]
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

        private void Start()
        {
            ResetLevel();
        }

        public void ResetLevel()
        {
            if (sliderH_I)
                DestroyImmediate(sliderH_I.gameObject);

            DeploySliderHead();
        }

        void DeploySliderHead()
        {
            if (sliderH_prefab != null && sliderH_I == null)
                sliderH_I = Instantiate<SliderHead>(sliderH_prefab,sliderP_Start.transform.position, sliderP_Start.transform.rotation);
        }
    }
}
