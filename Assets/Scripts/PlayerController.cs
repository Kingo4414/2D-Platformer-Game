using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jump;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        Debug.Log("Player Controller Awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
       
        MoveCharacter(horizontal, vertical);
        PlayerMovemntAnimation(horizontal, vertical);


       

    }

    private void MoveCharacter(float horizontal,float vertical)
    {  //MoveCharacter horizontally
        Vector3 position = transform.position;
        position.x +=  horizontal * speed * Time.deltaTime;
        transform.position = position;

        //MoveCharacter vertically
        if (vertical > 0) {
            rb2d.AddForce(new Vector2(0f,jump),ForceMode2D.Force);
        }

    }

    private void Crouch() {
        bool crouch = Input.GetKey("left ctrl");

        if (crouch == true)
        {
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.53f, 1.29f);
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0.02f, 0.59f);

            animator.SetBool("Crouch", true);
            //   Debug.Log("right ctrl keydown bool pressed...");
        }
        else if (crouch == false)
        {
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.62f, 2.01f);
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0.02f, 0.97f);

            animator.SetBool("Crouch", false);
           
        }

    }
  
    private void PlayerMovemntAnimation(float horizontal, float vertical) {
       
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        Crouch();

        //Jump   
        animator.SetBool("Jump", false);

        if (vertical > 0)
        {

            animator.SetBool("Jump", true);
            Debug.Log("jump >0 pressed..." + vertical);

        }
        else if (vertical < 0)
        {
            animator.SetBool("Jump", false);
            Debug.Log("jump <0 pressed..." + vertical);
        }
        // transform.localScale = scale;

        /*Input.GetAxisRaw("Vertical");
        Input.GetKeyDown(KeyCode.Space);*/

    }



}
