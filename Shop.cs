using UnityEngine.UI;
using UnityEngine;

public class Shop : MonoBehaviour {

	BuildManager buildManager;

	void Start()
	{
		buildManager = BuildManager.instance;
		ShowShopPrice ();
	}

	public void PurchaseAssaultTower()
	{
		buildManager.SetTurretToBuild (buildManager.Assault_Tower);
	}

	public void PurchaseMissileTower()
	{
		buildManager.SetTurretToBuild (buildManager.Missile_Tower);
	}

	public void PurchaseFlameThrowerTower()
	{
		buildManager.SetTurretToBuild (buildManager.FlameThrower_Tower);
	}

	public void PurchaseShockWaveTower()
	{
		buildManager.SetTurretToBuild (buildManager.Pulse_Tower);
	}


	private void ShowShopPrice()
	{
		
		Transform textbox;
		Text text;

		//Get list of all children (each shop item)
		Transform[] children = GetChildren ();

		//Find the children that have UI Text of Price
		foreach (Transform child in children) 
		{
			switch (child.name) 
			{
			case "Assault":
				//Get reference to textbox and set
				textbox = child.transform.Find ("Text");
				text = textbox.GetComponent<Text> ();
				text.text = "Assault     45";
				break;

			case "Missile":
				//Get reference to textbox and set
				textbox = child.transform.Find ("Text");
				text = textbox.GetComponent<Text> ();
				text.text = "Missile     100";
				break;

			case "FlameThrower":
				//Get reference to textbox and set
				textbox = child.transform.Find ("Text");
				text = textbox.GetComponent<Text> ();
				text.text = "FlameThrower     150";
				break;

			case "Pulse":
				//Get reference to textbox and set
				textbox = child.transform.Find ("Text");
				text = textbox.GetComponent<Text> ();
				text.text = "Pulse     200";
				break;
			default:
				Debug.Log ("Found Nothing");
				break;

			}

		}

	}

	private Transform[] GetChildren()
	{
		Transform[] children = new Transform[transform.childCount];
		for (int i = 0; i < children.Length; i++)
		{
			children[i] = transform.GetChild(i);

		}
		return children;
	}


}
