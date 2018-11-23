using UnityEngine;

namespace GameCore { 
public class Player_ShooterCtrl : MonoBehaviour {

        Player_Manager myMng;

        Transform shootingPoint { get { return myMng.ShootingPoint; } }
        GameObject projectilePrefab { get { return myMng.ProjectilePrefab; } }

        float shootForce { get { return myMng.Data.ShootForce; } }

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
            GameObject projectile = Instantiate<GameObject>(projectilePrefab, shootingPoint.position, shootingPoint.rotation);
            projectile.GetComponent<ConstantForce2D>().force = Vector2.right * shootForce;
        }
	}
}
