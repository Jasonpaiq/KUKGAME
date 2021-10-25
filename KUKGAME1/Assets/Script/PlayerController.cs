using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.5f;
    public float rotSpeed = 0;
    float newX = 0;
    float newY = 0;
    float newZ = 0;
    float newRoty = 0;
    
    void Update()
    {
        newY = transform.position.y;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            newZ = transform.position.z + speed * Time.deltaTime;
            newRoty = 0;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            newZ = transform.position.z - speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, -180, 0);
            newRoty = 180;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            newX = transform.position.x + speed * Time.deltaTime;
            newRoty = 90;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newX = transform.position.x - speed * Time.deltaTime;
            newRoty = -90;
        }

        transform.position = new Vector3(newX, newY, newZ);
        transform.rotation = Quaternion.Lerp(
                                                Quaternion.Euler(0, newRoty, 0),
                                                transform.rotation,
                                                Time.deltaTime* rotSpeed
                                            );

    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.name == "Ball")
        {
            transform.localScale = new Vector3(1,1,1);
        }
    }
    
}
