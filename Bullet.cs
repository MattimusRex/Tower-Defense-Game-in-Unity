using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;
    public float speed = 70f;
    public float AoERadius = 0f;
    public float damage = 20f;

    public void Seek(Transform _target)
    {
        target = _target;
    }
	
	// Update is called once per frame
	void Update () {
		if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
	}

    protected virtual void HitTarget()
    {
        if (AoERadius > 0f)
        {
            AoEDamage();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }

    protected virtual void AoEDamage()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, AoERadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }

    }

    void Damage(Transform enemy)
    {
        Enemy target = enemy.GetComponent<Enemy>();
        if (target != null)
        {
            target.TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AoERadius);
    }
}
