using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.DrawLine(ray.origin, hit.point);
            print(hit.collider.gameObject.name);
            print(hit.point.x);
            var posX = Mathf.Clamp(hit.point.x, -4f, 4f);
            this.transform.position = new Vector3(posX, transform.position.y, transform.position.z);
        }
    }
}
