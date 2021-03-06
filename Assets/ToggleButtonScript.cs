﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButtonScript : MonoBehaviour {

    public Button toggleButton;
    public Text buttonText;
    public GameObject panel, champion;
    public string playerName;

	[Header("UI Animation")]
	private RectTransform window;
	private Vector3 originalPosition;
	private float animationDistance;
	private Vector3 champOriginalScale;

	void Awake()
	{
		animationDistance = Screen.height * 2f;
		window = panel.GetComponent<RectTransform>();

		champOriginalScale = champion.transform.localScale;
	}

	private void OnEnable()
	{
		originalPosition = window.anchoredPosition3D;
	}

    // Use this for initialization
	void Start () {
        toggleButton.GetComponent<Button>();
        toggleButton.onClick.AddListener(TaskOnClick);

        panel.SetActive(false);

        SetButtonText();
	}

	void TaskOnClick()
	{
		window.anchoredPosition3D += new Vector3(0f, -animationDistance, 0f);

		panel.SetActive(!panel.activeSelf);

		LeanTween
			.moveY(this.window, this.window.anchoredPosition3D.y + this.animationDistance, 0.2f)
			.setEase(LeanTweenType.easeOutSine);

		if (panel.activeSelf) {
			LeanTween
				.scale(champion.gameObject, Vector3.zero, 0.2f);
		} else {
			LeanTween
				.scale(champion.gameObject, champOriginalScale, 0.2f);
		}

        SetButtonText();
    }

    void SetButtonText()
	{
        string status = "STATS";

        if (panel.activeSelf)
        {
            status = "CHAMP";
        }

        buttonText.text = string.Format("{0} {1}", playerName, status);
    }
}
