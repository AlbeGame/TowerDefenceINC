using UnityEngine;

namespace GameCore {
    public class TransitionTrigger : MonoBehaviour
    {
        public int NextLevelID = -1;
        LevelManager lvlMng;

        // Use this for initialization
        void Start()
        {
            lvlMng = FindObjectOfType<LevelManager>();
            GetComponent<SpriteRenderer>().color = Color.clear;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (NextLevelID == -1)
                return;

            lvlMng.ChangeLevel(NextLevelID);
        }
    }
}
