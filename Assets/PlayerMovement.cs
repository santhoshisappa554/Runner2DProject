using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    
    public float jumpvelocity;
    bool grounded = true;
    Animator animator;
    Rigidbody2D playerRb;
    public Canvas canvas;
    public SpawnManager oc;
    public RepeatBackGround bg;
    public RepeatBackGround ug;
    public RepeatBackGround dg;



    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        oc = FindObjectOfType<SpawnManager>();
        bg = GameObject.Find("BackGround").GetComponent<RepeatBackGround>();
        ug= GameObject.Find("Ground").GetComponent<RepeatBackGround>();
        dg = GameObject.Find("Ground").GetComponent<RepeatBackGround>();


    }

    // Update is called once per frame
    void Update()
    {
        //this.GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed, 0);
        if (Input.GetButtonDown("Fire1"))
        {
            if (grounded && animator.enabled)
            {
                jumpMovement();
                animator.SetTrigger("Jump");
                
            }
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
          
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            
            //Destroy(this.gameObject, 0.0f);
            animator.SetTrigger("Dead");
            canvas.gameObject.SetActive(true);
            //animator.enabled=false;
            oc.CancelInvoke("Spawn");
            bg.xoffset = 0.0f;
            ug.xoffset = 0.0f;
            dg.xoffset = 0.0f;
           
        }

    }
    
    private void jumpMovement()
    {
        
        playerRb.velocity = new Vector2(0, jumpvelocity);
        print("Jumped");
        grounded = false;
    }
    
}
