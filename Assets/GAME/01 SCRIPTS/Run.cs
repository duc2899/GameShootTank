using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    Vector3 movement = new Vector3(0, 0, 0);
   
    [SerializeField] float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("go");
    }
    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = transform.rotation;   
        // Reset movement vector mỗi frame
        movement.x = 0;
        movement.y = 0;
          
        // Xử lý các đầu vào
        if (Input.GetKey(KeyCode.A))
        {
          
            rotation.eulerAngles += new Vector3(0, 0, 40) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement.y = -speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            movement.y = speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotation.eulerAngles += new Vector3(0, 0, -40) * Time.deltaTime;
        }

        

        // Di chuyển
        transform.Translate(movement * Time.deltaTime);
        transform.rotation = rotation;
    }
}
