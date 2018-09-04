using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButtonScript : MonoBehaviour {

    public Button toggleButton;
    public Text buttonText;
    public GameObject panel;
    public string playerName;

    // Use this for initialization
	void Start () {
        toggleButton.GetComponent<Button>();
        toggleButton.onClick.AddListener(TaskOnClick);
        panel.SetActive(false);
        SetButtonText();
        
	}
	
    void TaskOnClick(){
      
        panel.SetActive(!panel.activeSelf);
        SetButtonText();
    }

    void SetButtonText(){

        string status = "STATS";
        if (panel.activeSelf)
        {
            status = "CHAMP";
        }

        buttonText.text = string.Format("{0} {1}", playerName, status);
    }
}
