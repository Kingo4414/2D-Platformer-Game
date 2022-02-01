using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       

        Crouch();

        Jump();
        Speed();


       

    }

    public void Crouch() {
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
    public void Jump() {
        animator.SetBool("Jump", false);
        float jump = Input.GetAxisRaw("Vertical");
        
        Vector3 scale = transform.localScale;
        if (jump > 0)
        {
            
            animator.SetBool("Jump", true);
           scale.x = -1f * Mathf.Abs(scale.x);
            Debug.Log("jump >0 pressed..." +jump);
            
        }
        else if (jump == 0)
        { 
            animator.SetBool("Jump", false);
           scale.x = Mathf.Abs(scale.x);
            Debug.Log("jump <0 pressed..." + jump);
        }
       // transform.localScale = scale;
        
    }
    public void Speed() {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

    }
        
        
        
        }
