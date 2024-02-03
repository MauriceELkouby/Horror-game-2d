using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  //utilities
  private float timer = 2;
  Rigidbody2D rb;
  private Animator anim;

  //movement and directions
  [SerializeField]private float movSpeed;
  public static float speedX, speedY; 
  float dash = 1;
  float scaledDirection;
  public static bool isDashing= false;
  public static int currentDirection = 0;
  public static bool isStill = false;
  
  //weapons
  [SerializeField]private GameObject bulletPrefab;
  private bool loaded = true;
  
  private void Start(){
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
  }
  void Update(){
    
    //shooting
    if(Input.GetButtonDown("Fire1")){
      if(loaded && !isDashing){
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        loaded = false;
        anim.SetBool("isAttacking",true);
        Invoke("reload",0.3f);
        }
      }

    //direction
    scaledDirection = currentDirection/8f;
    anim.SetFloat("direction",scaledDirection);
    switch (GetSign(speedX))
    {
        case 1 when speedY == 0:
            currentDirection = 1;
            break;
        case 1 when speedY > 0:
            currentDirection = 2;
            break;
        case 0 when speedY > 0:
            currentDirection = 3;
            break;
        case -1 when speedY > 0:
            currentDirection = 4;
            break;
        case -1 when speedY == 0:
            currentDirection = 5;
            break;
        case -1 when speedY < 0:
            currentDirection = 6;
            break;
        case 0 when speedY < 0:
            currentDirection = 7;
            break;
        case 1 when speedY < 0:
            currentDirection = 8;
            break;
        default:
            // No change in direction
            break;
    }
    
    //utility
    timer += Time.deltaTime;

    //dashing
    if(timer <= 0.3f){
      anim.SetBool("isDashing",true);
      isDashing = true;
      dash = 3f;
    }
    else{
      anim.SetBool("isDashing",false);
      if(loaded){
      anim.SetBool("isWalking",!isStill);
      }
      isDashing = false;
      dash = 1f;
    }
    if(Input.GetButtonDown("Jump")){
      if(timer >= 0.75f){
        timer = 0;
      }
    }
    
    //movement
    speedX = Input.GetAxis("Horizontal");
    speedY = Input.GetAxis("Vertical");
    if(speedX != 0f || speedY != 0f){
      rb.velocity = new Vector2(speedX, speedY) * movSpeed * dash;
      isStill = false;
      }
    else{
      isStill = true;  
      rb.velocity = new Vector2(0,0);
    }
    
  }
  
  int GetSign(float value)
  {
      return (value > 0) ? 1 : (value < 0) ? -1 : 0;
  }
  
  void reload(){
    loaded = true;
    anim.SetBool("isAttacking",false);
  }
  }