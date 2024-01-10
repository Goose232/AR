using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSystem : MonoBehaviour
{
   
    [Header("Firing Properties")]
    public float maxProjectileForce = 100f;
    public float coolDown = 1f;

    [Header("Projectile Properties")]
    public GameObject projectilePrefab;

    Transform projectileSpawnTransform;
    bool canShoot = true;
  //  Animator anim;


    public void fireProjectile()
    {
        projectileSpawnTransform = GameObject.Find("FirePos").transform;
        
        if (!canShoot)
            return;

        GameObject fire = (GameObject)Instantiate(projectilePrefab, projectileSpawnTransform.position, projectileSpawnTransform.rotation);
        Vector3 force = projectileSpawnTransform.transform.right*(-maxProjectileForce);
        fire.GetComponent<Rigidbody>().AddForce(force);

        canShoot = false;
        Invoke("CoolDown", coolDown);
    }

    void CoolDown()
    {
        canShoot = true;
    }


}
