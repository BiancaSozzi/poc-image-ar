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

    [Header("UI Animation")]
    private RectTransform window;
    private Vector3 originalPosition;
    private float animationDistance;

    void Awake()
    {
        animationDistance = Screen.height * 2f;
    }

    private void OnEnable()
    {
    }

    void Start () {
        playerButtons[0].onClick.AddListener(OpenPanel1);
        playerButtons[1].onClick.AddListener(OpenPanel2);
        playerButtons[2].onClick.AddListener(OpenPanel3);
        playerButtons[3].onClick.AddListener(OpenPanel3);
        HidePanels();
    }

    public void OpenPanel1()
    {
        OpenPanel(0);
    }

    public void OpenPanel2()
    {
        OpenPanel(1);
    }

    public void OpenPanel3()
    {
        OpenPanel(2);
    }

    void OpenPanel(int index) {
        window = playerPanels[index].GetComponent<RectTransform>();

        buttonsPanel.SetActive(false);

        window.anchoredPosition3D += new Vector3(0f, -animationDistance, 0f);

        playerPanels[index].SetActive(true);

        LeanTween
            .moveY(this.window, this.window.anchoredPosition3D.y + this.animationDistance, 0.2f)
            .setEase(LeanTweenType.easeOutSine);
    }

    public void HidePanels(){
        for (int i = 0; i < playerPanels.Length; i++)
        {
            playerPanels[i].SetActive(false);
        }
        buttonsPanel.SetActive(true);
    }


}
