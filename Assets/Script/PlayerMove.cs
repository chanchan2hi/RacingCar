using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    private float moveSpeed = 5f;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0);
      // Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0,0);
       transform.Translate(movement * moveSpeed * Time.deltaTime);
        
    }
}
