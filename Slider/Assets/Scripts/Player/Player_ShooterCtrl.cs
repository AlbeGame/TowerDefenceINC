using UnityEngine;

namespace GameCore { 
public class Player_ShooterCtrl : MonoBehaviour {

        Player_Manager myMng;

        Transform shootingPoint { get { return myMng.ShootingPoint; } }
        GameObject projectilePrefab { get { return myMng.ProjectilePrefab; } }

        float shootForce { get { return myMng.Data.ShootForce; } }
        float fireRate { get { return myMng.Data.FireRate; } }

        private void Update()
        {
            Recharge();
        }

        public bool isRightFacing { get; private set; }

        public void Init(Player_Manager _mng)
        {
            myMng = _mng;

            isRightFacing = true;
        }

        public void RevertShootingDirection()
        {
            if (!isRightFacing)
            {
                isRightFacing = !isRightFacing;
                shootingPoint.RotateAround(shootingPoint.parent.position, Vector3.forward, 180);
            }
            else
            {
                isRightFacing = !isRightFacing;
                shootingPoint.RotateAround(shootingPoint.parent.position, Vector3.forward, 180);
            }
        }

        public void Shoot()
        {
            if (isRecharging)
                return;

            GameObject projectile = Instantiate<GameObject>(projectilePrefab, shootingPoint.position, shootingPoint.localRotation);
            projectile.GetComponent<ConstantForce2D>().force = shootingPoint.right * shootForce;
            isRecharging = true;
        }

        bool isRecharging;
        float fireRateCooldown;
        void Recharge()
        {
            if (!isRecharging)
                return;
            else
            {
                fireRateCooldown += Time.deltaTime;
                if(fireRateCooldown >= fireRate)
                {
                    isRecharging = false;
                    fireRateCooldown = 0;
                }
            }
        }
	}
}
