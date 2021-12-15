using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public AudioMixer audio; 
    public GameObject pauseGeam;
    public void PalGeam()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGeam()
    {
        Application.Quit();
    }
    public void UiEnable()
    {
        GameObject.Find("Canvas/mainMeun/UI").SetActive(true);
      
    }
    public void OpEnble()
    {
        SceneManager.LoadScene("MenuOptions");
    }
    public void PauseGeam()
    {
        pauseGeam.SetActive(true);
        Time.timeScale = 0f;
    }
    public void pauseGeam0()
    {
        pauseGeam.SetActive(false);
        Time.timeScale = 1f;
    }
    public void SetVluam(float valun)
    {
        audio.SetFloat("mixAdio", valun);
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
}
