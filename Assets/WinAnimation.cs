using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinAnimation : DefaultTrackableEventHandler {

    public GameObject panel_teams;
    public GameObject panel_cup;

    [Header("UI Animation")]
    private RectTransform window_team;
    private RectTransform window_cup;
    private Vector3 originalPosition_team;
    private Vector3 originalPosition_cup;
    private float animationDistance;

    void Awake()
    {
        animationDistance = Screen.height * 2f;
        window_team = panel_teams.GetComponent<RectTransform>();
        window_cup = panel_cup.GetComponent<RectTransform>();
        originalPosition_team = window_team.anchoredPosition3D;
        originalPosition_cup = window_cup.anchoredPosition3D;
    }

    protected override void OnTrackingFound(){

        base.OnTrackingFound();
        // panel_cup.SetActive(false);
        // panel_teams.SetActive(true);

        window_team.anchoredPosition3D += new Vector3(0f, -animationDistance, 0f);
		window_cup.anchoredPosition3D += new Vector3(0f, -animationDistance, 0f);

        LeanTween
            .moveY(this.window_team, this.window_team.anchoredPosition3D.y + this.animationDistance, 3f)
            .setEase(LeanTweenType.easeInOutElastic);

        StartCoroutine(HidePanel(this.window_team));
    }

    public IEnumerator HidePanel(RectTransform window)
    {

        yield return new WaitForSeconds(10);

        LeanTween
            .moveY(window, window.anchoredPosition3D.y - this.animationDistance, 3f)
            .setEase(LeanTweenType.easeOutSine);

		yield return new WaitForSeconds(1);

		LeanTween
            .moveY(this.window_cup, this.window_cup.anchoredPosition3D.y + this.animationDistance, 3f)
            .setEase(LeanTweenType.easeInOutElastic);

        StartCoroutine(HideCupPanel(this.window_cup));
    }

    public IEnumerator HideCupPanel(RectTransform window)
    {
        yield return new WaitForSeconds(10);

        LeanTween
            .moveY(window, window.anchoredPosition3D.y - this.animationDistance, 3f)
            .setEase(LeanTweenType.easeOutSine);

        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("poc-images-ar", LoadSceneMode.Single);

    }
}

