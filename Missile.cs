using UnityEngine;

public class Missile : Bullet {

    public GameObject explosionEffect;

    protected override void HitTarget()
    {
        AoEDamage();
        GameObject explosion = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);
        explosion.GetComponent<ParticleSystem>().Emit(500);
        Destroy(explosion, 1f);
        Destroy(gameObject);
    }
}
