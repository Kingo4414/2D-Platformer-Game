using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        MoveCharacter(horizontal);
        PlayerMovemntAnimation(horizontal);


       

    }

    private void MoveCharacter(float horizontal)
    {
        Vector3 position = transform.position;
        position.x +=  horizontal * speed * Time.deltaTime;
        transform.position = position;
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
  
    private void PlayerMovemntAnimation(float horizontal) {
       
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

        animator.SetBool("Jump", false);
        float jump = Input.GetAxisRaw("Vertical");

        
        if (jump > 0)
        {

            animator.SetBool("Jump", true);
            scale.x = -1f * Mathf.Abs(scale.x);
            Debug.Log("jump >0 pressed..." + jump);

        }
        else if (jump < 0)
        {
            animator.SetBool("Jump", false);
            scale.x = Mathf.Abs(scale.x);
            Debug.Log("jump <0 pressed..." + jump);
        }
        // transform.localScale = scale;

        /*Input.GetAxisRaw("Vertical");
        Input.GetKeyDown(KeyCode.Space);*/

    }



}
