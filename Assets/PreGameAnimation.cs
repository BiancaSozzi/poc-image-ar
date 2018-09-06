using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PreGameAnimation : DefaultTrackableEventHandler{

    public Text timer_text;
    //private float time_remaining = 10; // in seconds

    public GameObject panel_timer;
    public GameObject panel_begin_game;

    [Header("UI Animation")]
    private RectTransform window_timer;
    private RectTransform window_begin_game;
    private Vector3 originalPosition_timer;
    private Vector3 originalPosition_begin_game;
    private float animationDistance;



    void Awake()
    {
        animationDistance = Screen.height * 2f;
        window_timer = panel_timer.GetComponent<RectTransform>();
        window_begin_game = panel_begin_game.GetComponent<RectTransform>();
        originalPosition_timer = window_timer.anchoredPosition3D;
        originalPosition_begin_game = window_begin_game.anchoredPosition3D;
    }

    void Update()
    {
        if (timer_text.text.Contains("00:00:00"))
        {
            StartCoroutine(HidePanelTimer(this.window_timer));
        }

    }

    protected override void OnTrackingFound()
    {

        base.OnTrackingFound();

        window_timer.anchoredPosition3D += new Vector3(0f, -animationDistance, 0f);
        window_begin_game.anchoredPosition3D += new Vector3(0f, -animationDistance, 0f);

        LeanTween
            .moveY(this.window_timer, this.window_timer.anchoredPosition3D.y + this.animationDistance, 3f)
            .setEase(LeanTweenType.easeInOutSine);

    }

    public IEnumerator HidePanelTimer(RectTransform window)
    {

        LeanTween
            .moveY(window, window.anchoredPosition3D.y - this.animationDistance, 3f)
            .setEase(LeanTweenType.easeOutSine);

        yield return new WaitForSeconds(0);

        LeanTween
            .moveY(this.window_begin_game, this.window_begin_game.anchoredPosition3D.y + this.animationDistance, 3f)
            .setEase(LeanTweenType.easeInOutSine);

        StartCoroutine(HidePanelGameBegins(this.window_begin_game));



    }

    public IEnumerator HidePanelGameBegins(RectTransform window)
    {
        yield return new WaitForSeconds(10);

        LeanTween
            .moveY(window, window.anchoredPosition3D.y - this.animationDistance, 3f)
            .setEase(LeanTweenType.easeOutSine);

        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("match-presentation", LoadSceneMode.Single);

    }

}
