using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour
{
    private Rigidbody2D myrigidbody;
    public float BunnyJumpForce = 500f;
    
    // Start is called before the first frame update
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Jump"))
        {
            myrigidbody.AddForce(transform.up * BunnyJumpForce);
        }
    }
}
