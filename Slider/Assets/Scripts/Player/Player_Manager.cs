using UnityEngine;

namespace GameCore { 
public class Player_Manager : MonoBehaviour {

        [SerializeField]
        Player_Data data;
        public Player_Data Data
        {
            get { return data; }
        }

        [SerializeField]
        Transform shootingPoint;
        public Transform ShootingPoint
        {
            get { return shootingPoint; }
        }
        [SerializeField]
        GameObject projectilePrefab;
        public GameObject ProjectilePrefab
        {
            get { return projectilePrefab; }
        }

        Player_MovementCtrl moveCtrl;
        Player_ShooterCtrl shootCtrl;

        GameManager gameMng;

        private void Start()
        {
            gameMng = GameManager.I;

            MovementInit();
            ShooterInit();

            gameMng.UI_Ctrl.AddListenerToBtn(() => GoLeft(), UI_CustomButton.ButtonType.Left);
            gameMng.UI_Ctrl.AddListenerToBtn(() => GoRight(), UI_CustomButton.ButtonType.Right);
            gameMng.UI_Ctrl.AddListenerToBtn(() => Jump(), UI_CustomButton.ButtonType.Up);
        }
        #region Init
        private void MovementInit()
        {
            moveCtrl = gameObject.AddComponent<Player_MovementCtrl>();
            moveCtrl.Init(this);
        }

        private void ShooterInit()
        {
            shootCtrl = gameObject.AddComponent<Player_ShooterCtrl>();
            shootCtrl.Init(this);
        }
        #endregion
        #region Actions
        public void GoRight()
        {
            moveCtrl.MoveRight();
            if (!shootCtrl.isRightFacing)
                shootCtrl.RevertShootingDirection();
        }

        public void GoLeft()
        {
            moveCtrl.MoveLeft();
            if (shootCtrl.isRightFacing)
                shootCtrl.RevertShootingDirection();
        }

        public void Jump()
        {
            moveCtrl.Jump();
        }

        public void Shoot()
        {
            shootCtrl.Shoot();
        }
        #endregion
    }
}
