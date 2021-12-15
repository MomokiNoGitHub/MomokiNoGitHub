using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager intstatic;//静态类生成
    public AudioSource audioSound;
    [SerializeField]//私有显示
    private AudioClip JumpAuido, huatAuido, cherryAuido, dateAudio;

    private void Awake()
    {
        intstatic = this;
    }
    public void jumpAuido()
    {
        audioSound.clip = JumpAuido;
        audioSound.Play();

    }
    public void HuatAuido()
    {
        audioSound.clip = huatAuido;
        audioSound.Play();

    }
    public void CherryAuido()
    {
        audioSound.clip = cherryAuido;
        audioSound.Play();

    }
    public void DateAudio()
    {
        audioSound.clip = dateAudio;
        audioSound.Play();

    }
}
