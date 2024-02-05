using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
  private float projectileSpeedX, projectileSpeedY;
  Rigidbody2D rb;
  
  private void Start(){
    if(PlayerController.currentDirection == 1){
      projectileSpeedX = 1;
      projectileSpeedY = 0;
    }
    if(PlayerController.currentDirection == 2){
      projectileSpeedX = 0.75f;
      projectileSpeedY = 0.75f;
    }
    if(PlayerController.currentDirection == 3){
      projectileSpeedX = 0;
      projectileSpeedY = 1;
    }
    if(PlayerController.currentDirection == 4){
      projectileSpeedX = -0.75f;
      projectileSpeedY = 0.75f;
    }
    if(PlayerController.currentDirection == 5){
      projectileSpeedX = -1;
      projectileSpeedY = 0;
    }
    if(PlayerController.currentDirection == 6){
      projectileSpeedX = -0.75f;
      projectileSpeedY = -0.75f;
    }
    if(PlayerController.currentDirection == 7){
      projectileSpeedX = 0;
      projectileSpeedY = -1;
    }
    if(PlayerController.currentDirection == 8){
      projectileSpeedX = 0.75f;
      projectileSpeedY = -0.75f;
    }
    rb = GetComponent<Rigidbody2D>();
    Invoke("destroy",2f);
  }
  private void Update(){
    rb.velocity = new Vector2(projectileSpeedX*30, projectileSpeedY*30);
  }
  private void destroy(){
    Destroy(gameObject);
  }

}