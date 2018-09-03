using UnityEngine;
using System.Collections;
using Vuforia;

public class CustomVirtualButtonEventHandler : MonoBehaviour,
                                               IVirtualButtonEventHandler
{
    public GameObject panel;
    void Start()
    {

        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; ++i)
        {
            vbs[i].RegisterEventHandler(this);
        }

    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("ACTUVE!");
        panel.SetActive(true);

    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        StartCoroutine(HidePanel());
    }

    public IEnumerator HidePanel()
    {
        Debug.Log("bye!");
        yield return new WaitForSeconds(4);

        panel.SetActive(false);

    }
}