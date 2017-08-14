using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//inherits Basic_Tower and overrides Fire() to include the assult tower particle effects
public class Assault_Tower : Basic_Tower {

    public ParticleSystem explosion_ps;
    public ParticleSystem shrapnel_ps;

    override protected void Fire()
    {
        explosion_ps.Emit(30);
        shrapnel_ps.Emit(30);
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
}
