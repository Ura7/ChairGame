using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KarakterKontrol : MonoBehaviour
{
    GameObject karakter;
    private Rigidbody2D rb;
    public  float Jump_ayar = 15f;

    public static bool isGameOver;
    

    public Transform groundCheck;
    
    public LayerMask groundLayer;
    
    bool isGrounded;
    Animator anim;

    

    [SerializeField] float fallMultiplier;
    [SerializeField] float jumpTime;
    [SerializeField] float jumpMultiplier;

    [SerializeField] private AudioSource jumpEffect;

    public bool oyunBitti = true;

    bool isJumping;
    float jumpCounter;
    Vector2 vecGravity;
    private void Awake(){
        isGameOver =false;
        
         rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {      
        vecGravity = new Vector2(0,-Physics2D.gravity.y);
       anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.37f,0.4f),CapsuleDirection2D.Horizontal,0,groundLayer);
        if(isGameOver==false){
        if(Input.GetMouseButtonDown(0)&& isGrounded)
         {
            jumpEffect.Play();
            Jump();
            isJumping = true;
            jumpCounter=0;
         }
        

         if(rb.velocity.y>0 && isJumping)
         {
            jumpCounter +=Time.deltaTime;
            if(jumpCounter>jumpTime) isJumping = false;
            float t = jumpCounter / jumpTime;
            float currentJumpM = jumpMultiplier;

            if(t>0.5f)
            {
                currentJumpM = jumpMultiplier * (1-t);
            }

            rb.velocity +=vecGravity*currentJumpM*Time.deltaTime;
         }

         if(Input.GetButtonUp("Fire1"))
         {
            isJumping = false;
            jumpCounter =0;
            if(rb.velocity.y>0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y*0.5f);
            }
         }

        if(rb.velocity.y<0)
        {
            rb.velocity -= vecGravity*fallMultiplier*Time.deltaTime;
        }
        }
        else 
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            
            
        }
        setAnimation();
        
    }
    private void Jump()
    {
        rb.velocity = Vector2.up * Jump_ayar;
        
    }
    void setAnimation()
    {
        if(rb.velocity.y==0 || isGrounded)
        {
            anim.SetBool("isFall",false);
            anim.SetBool("isJumping",false);
            
        }
        if(rb.velocity.y>0 && isJumping)
        {
            anim.SetBool("isJumping",true);
            anim.SetBool("isFall",false);
            

        }
        if(rb.velocity.y<0 )
        {
            anim.SetBool("isFall",true);
            anim.SetBool("isJumping",false);

        }

    }

    

    
    
}
