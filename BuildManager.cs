using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour {
    public static BuildManager instance;
    private GameObject turretToBuild;
    public GameObject Assault_Tower;
	public GameObject Missile_Tower;
	public GameObject FlameThrower_Tower;
	public GameObject Pulse_Tower;




    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than 1 build manager in scene");
            return;
        }
        instance = this;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

	public void SetTurretToBuild(GameObject turret)
	{
		turretToBuild = turret;
	}


}
