using UnityEngine;

namespace GameCore
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField]
        private SliderHead sliderH_prefab;
        private SliderHead sliderH_I;
        [SerializeField]
        private SliderPath sliderP_Start;

        // Use this for initialization
        void Start()
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
                sliderH_I = Instantiate<SliderHead>(sliderH_prefab, sliderP_Start.transform.position, sliderP_Start.transform.rotation);
        }
    }
}
