using UnityEngine;

namespace GameCore {
    public class TargetTrigger : MonoBehaviour
    {
        public int NextLevelID;
        LevelManager lvlMng;

        // Use this for initialization
        void Start()
        {
            lvlMng = FindObjectOfType<LevelManager>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            lvlMng.ChangeLevel(NextLevelID);
        }
    }
}
