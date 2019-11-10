using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{

    //Movement Variables
    public float movespeed = 5f;// velocity of the player

    Vector3 moveVelocity; // direction in wich the player moves

    PlayerController controller;// movement controller 

    bool canMove;// it enables the ability of the player to move

    public Gun gunController;// the logic of the gun
    

    void Start()
    {
        // get the controller componet
        controller = GetComponent<PlayerController>();

        //s tart state variables
        canMove = true; // at the bigining of the game the player can move around
    }


    void Update()
    {
        // rotate the player
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane GroundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (GroundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            controller.LookAt(point);
        }

        //first see if the player can move
        if (canMove )//GameManager.instance.inGame)
        {
            moveVelocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
           
            
            //move the player using the methods at the controller
            controller.Move(moveVelocity * movespeed);

        }


        if (Input.GetButtonDown("Shoot"))
        {
           gunController.Shoot();
        }
       

    }
   

}