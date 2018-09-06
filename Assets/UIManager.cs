using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Button[] playerButtons;
    public GameObject[] playerPanels;
    public GameObject buttonsPanel;
 
    // Use this for initialization
    void Start () {
        playerButtons[0].onClick.AddListener(OpenPanel1);
        playerButtons[1].onClick.AddListener(OpenPanel2);
        playerButtons[2].onClick.AddListener(OpenPanel3);
        HidePanels();
    }

    public void OpenPanel1()
    {
        Debug.Log("asdasd");
        buttonsPanel.SetActive(false);
        playerPanels[0].SetActive(true);

    }

    public void OpenPanel2()
    {
      
    }

    public void OpenPanel3()
    {

    }

    public void HidePanels(){
        for (int i = 0; i < playerPanels.Length; i++)
        {
            playerPanels[i].SetActive(false);
        }
        buttonsPanel.SetActive(true);
    }


}
