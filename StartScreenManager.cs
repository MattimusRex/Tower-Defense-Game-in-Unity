using UnityEngine.UI;
using UnityEngine;

public class StartScreenManager : MonoBehaviour {

    public Button firstLevel;
    public Button secondLevel;
    public Button thirdLevel;
    public Button fourthLevel;

	// Use this for initialization
	void Start () {
        //if no record of player, create record and unlock level 1 only
        //make the key the same as the scene name for it to work!
		if (!PlayerPrefs.HasKey("returning"))
        {
            PlayerPrefs.SetInt("returning", 1);
            PlayerPrefs.SetInt("firstLevel", 1);
            PlayerPrefs.SetInt("secondLevel", 0);
            PlayerPrefs.SetInt("thirdLevel", 0);
            PlayerPrefs.SetInt("fourthLevel", 0);
        }

        //enable buttons
        EnableButtons();
	}

    void EnableButtons()
    {
        firstLevel.interactable = true;

        if (PlayerPrefs.GetInt("secondLevel") == 1)
        {
            secondLevel.interactable = true;
        }
        else
        {
            secondLevel.interactable = false;
        }

        if (PlayerPrefs.GetInt("thirdLevel") == 1)
        {
            thirdLevel.interactable = true;
        }
        else
        {
            thirdLevel.interactable = false;
        }

        if (PlayerPrefs.GetInt("fourthLevel") == 1)
        {
            fourthLevel.interactable = true;
        }
        else
        {
            fourthLevel.interactable = false;
        }
    }

}
