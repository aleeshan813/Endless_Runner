using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public enum Platform_type
    {
        Straight,
        Turning
    }

    [SerializeField] Transform Endpoint;
    [SerializeField] public Platform_type Type = Platform_type.Straight;
    [SerializeField] List<GameObject> coins;

    public void OnEnable()
    {
        foreach (GameObject coin in coins) 
        {
            coin.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            instantiatePath();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Invoke("Removepath", 2f);
        }
    }
    void Removepath()
    {
        if (Type == Platform_type.Straight)
        {
            Platform_Manager.instance.AddStraightPath(gameObject);
        }
        else
        {
            Platform_Manager.instance.AddTurnPath(gameObject);
        }
    }

    void instantiatePath()
    {
        GameObject temp = Platform_Manager.instance.GetPath();

        temp.transform.position = Endpoint.position;
        temp.transform.rotation = Endpoint.rotation;

        temp.SetActive(true);
    }
}
