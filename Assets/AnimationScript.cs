using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationScript : DefaultTrackableEventHandler {

    public GameObject panel;

    [Header("UI Animation")]
    private RectTransform window;
    private Vector3 originalPosition;
    private float animationDistance;

    void Awake()
    {
        animationDistance = Screen.height * 2f;
        window = panel.GetComponent<RectTransform>();
        originalPosition = window.anchoredPosition3D;
    }

    protected override void OnTrackingFound(){
        base.OnTrackingFound();
        window.anchoredPosition3D += new Vector3(0f, -animationDistance, 0f);
        LeanTween
            .moveY(this.window, this.window.anchoredPosition3D.y + this.animationDistance, 3f)
            .setEase(LeanTweenType.easeInOutElastic);

        StartCoroutine(HidePanel());

    }

    public IEnumerator HidePanel()
    {

        yield return new WaitForSeconds(10);
        LeanTween
            .moveY(this.window, this.window.anchoredPosition3D.y - this.animationDistance, 3f)
            .setEase(LeanTweenType.easeOutSine);

        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("match-win", LoadSceneMode.Single);

    }


}



