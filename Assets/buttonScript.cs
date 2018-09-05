using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour {

    public void openTwitch(){
        Application.OpenURL("https://www.twitch.tv/faceittv");
    }
    public void openYouTube()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=fIVsRnP8Z-U");
    }

}
