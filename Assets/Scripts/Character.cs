using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    private SpriteRenderer spriterenderer;

    private void Start() 
    {
       spriterenderer = GetComponent<SpriteRenderer>(); 
    }
  
    void Update()
    {
      movement.x = Input.GetAxisRaw("Horizontal");
      movement.y = Input.GetAxisRaw("Vertical");

      animator.SetFloat("Horizontal", movement.x);
      animator.SetFloat("Vertical", movement.y);
      animator.SetFloat("Speed", movement.sqrMagnitude);

      if (Input.GetAxis("Horizontal") > 0.01f)
      {
        spriterenderer.flipX = false;
      } 
      else if (Input.GetAxis("Horizontal") < -0.01f)
      {
        spriterenderer.flipX = true;
      }
    }

    private void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void LateUpdate() 
    {
        
    }
}