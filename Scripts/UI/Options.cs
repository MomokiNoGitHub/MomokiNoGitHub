using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    public GameObject UI, AudioUI, LrUI, LangUI;
    public AudioMixer audio;

    public void Return()
    {
        SceneManager.LoadScene("Menu");
    }
    public void audioUIture()
    {
        UI.SetActive(false);
        AudioUI.SetActive(true);
    }
    public void audioUIfalse()
    {
        UI.SetActive(true);
        AudioUI.SetActive(false);
    }
    public void lrUItrue()
    {
        UI.SetActive(false);
        LrUI.SetActive(true);
    }
    public void lrUIfalse()
    {
        UI.SetActive(true);
        LrUI.SetActive(false);
    }
    public void langUItrue()
    {
        UI.SetActive(false);
        LangUI.SetActive(true);
    }
    public void langUIfalse()
    {
        UI.SetActive(true);
        LangUI.SetActive(false);
    }





    public void SetVluam(float valun)
    {
        audio.SetFloat("mixAdio", valun);
    }
    public void Bgm(float valun)
    {
        audio.SetFloat("Bgm", valun); 
    }
    public void Effect(float valun)
    {
        audio.SetFloat("effect", valun); 
    }

}
