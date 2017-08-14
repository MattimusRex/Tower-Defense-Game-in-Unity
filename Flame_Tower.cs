
using UnityEngine;

public class Flame_Tower : Basic_Tower {

    public ParticleSystem fire_ps;


    override protected void Fire()
    {
        fire_ps.Emit(100);
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
}
