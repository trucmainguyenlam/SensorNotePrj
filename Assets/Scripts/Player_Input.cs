using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    //CharacterController characterController;
    public float MovementSpeed = 1;
    public Transform tf;
    Camera cam;
    private float lastMousePoint = 0f;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        lastMousePoint = Input.GetAxis("Mouse X") * MovementSpeed;
        var x = Input.GetAxis("Mouse X") * MovementSpeed;
        //var y = Input.GetAxis("Mouse Y") * MovementSpeed;

        //transform.Rotate(x, y, 0);
        if(lastMousePoint != 0f)
        {
            Vector3 newPosition = new Vector3(x, 1.5f, 0f);
            tf.transform.position = newPosition;
        }

        //tf.transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, tf.transform.position.y, tf.transform.position.z));
        //tf.transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0f, 0f));
        //print(Input.mousePosition.x);

        //lastMousePoint = Input.GetAxis("Mouse X");
        //
        //float difference = Input.GetAxis("Mouse X") - lastMousePoint;
        //tf.transform.position = new Vector3(tf.transform.position.x + (difference / 188), tf.transform.position.y, tf.transform.position.z);
        //lastMousePoint = Input.GetAxis("Mouse X");
    }
}
