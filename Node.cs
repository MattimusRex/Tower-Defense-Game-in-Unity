using UnityEngine;

public class Node : MonoBehaviour {

    public Vector3 positionOffset;
    public Color hoverColor;
    private GameObject turret;
    private Color startColor;
    private Renderer rend;
	BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
		buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {

		if (buildManager.GetTurretToBuild () == null) 
		{
			return;
		}


        if (turret != null)
        {
            Debug.Log("Turret Already Built On This Square - TODO: display on screen");
            return;
        }
        else
        {
            GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
            if (turretToBuild.GetComponent<Basic_Tower>().cost > GameManager.currency)
            {
                Debug.Log("You don't have enough gold! - TODO: display on screen");
            }
            else
            {
                GameManager.currency -= turretToBuild.GetComponent<Basic_Tower>().cost;
                turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
            }
        }
    }

    void OnMouseEnter()
    {
		if (buildManager.GetTurretToBuild () == null) 
		{
			return;
		}

        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
