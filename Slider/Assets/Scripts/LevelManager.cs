using UnityEngine;

namespace GameCore
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField]
        GameObject playerPrefab;
        GameObject playerInstance;
        [SerializeField]
        Transform startPosition;

        void Start()
        {
            //Inject itself into GameManager
            GameManager.I.LevelMng = this;

            //Run level Setup
            ResetLevel();
        }

        #region API
        /// <summary>
        /// Change scene by ID
        /// </summary>
        /// <param name="_lvlID"></param>
        public void ChangeLevel(int _lvlID)
        {
            GameManager.I.ChangeLevel(_lvlID);
        }

        /// <summary>
        /// Reset current level(/scene)
        /// </summary>
        public void ResetLevel()
        {
            if (playerInstance)
                DestroyImmediate(playerInstance);

            DeployPlayer();
        }
        #endregion

        /// <summary>
        /// Instantiate player
        /// </summary>
        void DeployPlayer()
        {
            if (playerPrefab != null)
                playerInstance = Instantiate(playerPrefab, startPosition.position, startPosition.rotation);
        }
    }
}
