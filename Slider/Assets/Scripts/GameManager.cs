using UnityEngine.SceneManagement;
using UnityEngine;

namespace GameCore
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager I { get; private set; }

        public LevelManager LevelMng;
        public UI_Controller UI_Ctrl;

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

        public void ChangeLevel(int _levelID)
        {
            SceneManager.LoadScene(_levelID);
        }
    }
}
