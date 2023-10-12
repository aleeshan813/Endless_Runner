using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_collection : MonoBehaviour
{
    GameManager GManager;

    private void Start()
    {
        GManager = GameManager.Instance;
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        { 
          gameObject.SetActive(false);
        }

        GManager.Coincollected();
    }

     
}
