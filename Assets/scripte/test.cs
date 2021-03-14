using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test: MonoBehaviour
{
    CharacterController characterContoller;
    
    // Start is called before the first frame update
    void Start()
    {
       // rigidbody = GetComponent<Rigidbody>();
       // rigidbody.MovePosition(new Vector3(1, 2, 3));
        characterContoller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        /* if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Space)){
             Debug.Log("Shift+Spaceが押されたよ");
         }
        */
        //      Debug.Log($"Axisを取得({Input.GetAxisRaw("Horizontal")},{Input.GetAxisRaw("Vertical")})");

    }
}
