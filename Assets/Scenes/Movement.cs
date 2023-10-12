using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public Transform transform;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            transform.Rotate(new Vector3(9f, 0, 9f));

        if (Input.GetKeyDown(KeyCode.D))
            transform.Rotate(new Vector3(-9f, 0, 0));
    }
}
