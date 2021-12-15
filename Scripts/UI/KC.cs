using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KC : MonoBehaviour
{
    public int tiem;
    void Start()
    {
        StartCoroutine(waitte());
    }
    private void Update()
    {
        
    }
    IEnumerator waitte()
    {
        yield return new WaitForSeconds(tiem);

        SceneManager.LoadScene("Menu");
    }

}
