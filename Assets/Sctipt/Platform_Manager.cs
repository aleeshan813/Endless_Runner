using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Manager : MonoBehaviour
{
   public static Platform_Manager instance;
    [SerializeField] List<GameObject> StaraightPathPrefabs;
    Queue<GameObject> StraightPaths;

    int count = 0;

    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
            transform.parent = null;
        }
        else
        {
            Destroy(gameObject);
        }

        StraightPaths = new Queue<GameObject>();

        for (int i = 0; i < StaraightPathPrefabs.Count; i++)
        {
            GameObject GO = Instantiate(StaraightPathPrefabs[i], transform);
            AddStraightPath(GO);
        }

        GameObject firstobject = GetPath();
        firstobject.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        firstobject.SetActive(true);
    }

    public void AddStraightPath(GameObject GO)
    {
        GO.SetActive(false);
        StraightPaths.Enqueue(GO);
    }
    public void AddTurnPath(GameObject GO)
    {
        GO.SetActive(false);
        StraightPaths.Enqueue(GO);
    }

    public GameObject GetPath() 
    {
        count++;

        return StraightPaths.Dequeue();
    }
    GameObject GetStrainghtPath() 
    {
        GameObject GO;
        GO = StraightPaths.Dequeue();
        return GO;
    }

}
