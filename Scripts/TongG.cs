using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongG : MonoBehaviour
{

    public GameObject Tongwenz;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Tongwenz.SetActive(true);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Tongwenz.SetActive(false);

        }
    }
}
