using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public int pixelspu;

    public Animator animator;

    Vector2 movement;
    public Transform playerLoc;
    Vector2 oldPos;

    public bool movementEnabled = true;


    private float dir = 3;

    void Start() {
        ;
    }

    // Update is called once per frame
    void Update() {
        //Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        //input manager
        if (movementEnabled) {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        } else {
            movement.x = 0;
            movement.y = 0;
        }
        



        animator.SetFloat("Horizontal", movement.x);

        if (movement.x >= 0.01 || movement.x <= -0.01) {
            animator.SetFloat("Vertical", 0);
        } else {
            animator.SetFloat("Vertical", movement.y);
        }

        animator.SetFloat("Speed", movement.sqrMagnitude);


        //if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Jump")) { 

        if (movement.x == 0 && movement.y >= 0.01) {
            //up
            dir = 1;
            //Debug.Log("1");
        } else if (movement.x == 0 && movement.y <= -0.01) {
            //down
            dir = 2;
            //Debug.Log("2");
        } else if (movement.x >= 0.01) {
            //right
            dir = 3;
            //Debug.Log("3");
        } else if (movement.x <= -0.01) {
            //left
            dir = 4;
            //Debug.Log("4");
        } 
        //}
        

        animator.SetFloat("Dir", dir);
        //Debug.Log(dir);


    }

    void FixedUpdate() {
        //movement
        //* moveSpeed * Time.fixedDeltaTime
        movement *= moveSpeed;
        movement *= Time.fixedDeltaTime;
        //movement = PixelPerfectClamp(movement, pixelspu);

        
        oldPos.x = playerLoc.position.x;
        oldPos.y = playerLoc.position.y;
        //oldPos = PixelPerfectClamp(oldPos, pixelspu);

        
        rb.MovePosition(oldPos + movement);
        
    }




    // Could be useful later, for pixel perfect integration
    public Vector2 PixelPerfectClamp(Vector2 OhYeah, float ppu) {
        Vector2 vectorInPixels = new Vector2(
            Mathf.RoundToInt(OhYeah.x * ppu),
            Mathf.RoundToInt(OhYeah.y * ppu));

        //Debug.Log("Clamp x = " + vectorInPixels.x + " into " + vectorInPixels.x / ppu);
        //Debug.Log("Clamp y = " + vectorInPixels.y + " into " + vectorInPixels.y / ppu);

        return vectorInPixels / ppu;
    }

}
