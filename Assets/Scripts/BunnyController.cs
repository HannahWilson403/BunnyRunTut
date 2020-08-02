using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BunnyController : MonoBehaviour
{
    private Rigidbody2D myrigidbody;
    public float BunnyJumpForce = 500f;
    private Animator myAnim;
    private float bunnyHurtTime = -1;
    private Collider2D myCollider;
    public Text scoreText;
    private float startTime;




    
    // Start is called before the first frame update
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();

        startTime = Time.time;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (bunnyHurtTime == -1)
        {
            if (Input.GetButtonUp("Jump"))
            {
                myrigidbody.AddForce(transform.up * BunnyJumpForce);
            }

            myAnim.SetFloat("vVelocity", myrigidbody.velocity.y);
            scoreText.text = (Time.time - startTime).ToString("0.0");
        }

        else
        {
            if (Time.time > bunnyHurtTime + 2)
            {
             Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    [System.Obsolete]
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {

            foreach (PrefabSpawner spawner in FindObjectsOfType<PrefabSpawner>())
            {
                spawner.enabled = false;
            }

            foreach (MoveLeft moveLefter in FindObjectsOfType<MoveLeft>())
            {
                moveLefter.enabled = false;
            }

            bunnyHurtTime = Time.time;
            myAnim.SetBool("bunnyHurt", true);
            myrigidbody.velocity = Vector2.zero;
            myrigidbody.AddForce(transform.up * BunnyJumpForce);
            myCollider.enabled = false;
        }

    }
}
