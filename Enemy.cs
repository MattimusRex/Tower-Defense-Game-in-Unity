using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float speed = 10f;
    private float health;
    public float startHealth = 100f;
    public int value = 25;
    public bool isDead = false;
	public float ps_tower_damage =1f;

    //these are used to keep healthbar rotated towards camera when enemy rotates away
    public Transform enemyCanvas;
    private Quaternion faceForward;
    public Image healthBarImg;

    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
        health = startHealth;
        target = Waypoints.points[0];
        //get original healthbar rotation
        faceForward = enemyCanvas.rotation;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBarImg.fillAmount = health / startHealth;
        if (health <= 0)
        {
			//Coroutine needed because we need to wait to destroy object so that we can
			//play then "die" animation. 
			StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        if (this.isDead == false)
        {
            //subtract from number of enemies left
            GameManager.numberOfEnemiesLeft--;
            //Debug.Log(GameManager.numberOfEnemiesLeft);
            //add enemies value to the gameManager currency
            GameManager.currency += value;
            //mark as dead so turrets stop targetting
            this.isDead = true;
            //Stop zombie from flying around board after dying
            this.speed = 0f;
            //play die animation
            gameObject.GetComponent<Animator>().Play("die");
            //wait 2 seconds to destroy object so that animation can play out
            yield return new WaitForSeconds(2);
            //Finally, destroy GameObject
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

		//Rotate player to face direction they are walking
		transform.rotation = Quaternion.LookRotation(dir);


        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

    }

    //rotate healthbar back to original position
    void LateUpdate()
    {
        enemyCanvas.rotation = faceForward;
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            GameManager.lives--;
            GameManager.numberOfEnemiesLeft--;
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }



    void OnParticleCollision(GameObject tower)
    {
		TakeDamage (ps_tower_damage);
    }


}
