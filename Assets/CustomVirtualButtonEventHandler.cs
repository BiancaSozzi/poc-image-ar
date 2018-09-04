using UnityEngine;
using System.Collections;
using Vuforia;

public class CustomVirtualButtonEventHandler : MonoBehaviour,
                                               IVirtualButtonEventHandler
{
    public GameObject faker, vbutton;
    void Start()
    {
        vbutton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        faker = GameObject.Find("faker");
        faker.SetActive(false); 
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("ACTUVE!");
        faker.SetActive(true);

    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        StartCoroutine(HidePanel());
    }

    public IEnumerator HidePanel()
    {
        Debug.Log("bye!");
        yield return new WaitForSeconds(4);

        faker.SetActive(false);

    }
}