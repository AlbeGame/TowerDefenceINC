using UnityEngine;

namespace GameCore {
    [CreateAssetMenu(fileName = "NewPlayerData", menuName = "CreatePlayerData")]
    public class Player_Data : ScriptableObject {

        public float JumpForce = 5;
        public float SlideForce = 5;

        public float ShootForce = 1;
    }
}
