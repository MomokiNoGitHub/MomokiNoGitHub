using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 分辨率 : MonoBehaviour
{
    
    public void fullscreen()
    {
        Screen.fullScreen = true;
    }
    public void win()
    {
        Screen.fullScreen = false;
    }
    public void Oen()
    {

        Screen.SetResolution(1920, 1080, true);
    }
    public void two()
    {
        Screen.SetResolution(1280, 800, false);
    }
    public void three()
    {
        Screen.SetResolution(800, 600, false);
    }
}
