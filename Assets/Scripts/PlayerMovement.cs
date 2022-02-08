using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private float zMovement = 0f; //even though movement comes from up/down keys we actually want to modify where the player is on the Z plane

    private float xMovement = 0f;

    [SerializeField]
    private float speed = 5f;

    
    private CharacterController cc;

    private float gravity = -9.81f;
    private float yVelocity = 0.0f;

    //private float yVelocityWhenGrounded = -4.0f;


    // jumping vars

    private float time = 0.0f;
    private bool isMoving = false;
    private bool jumpPress = false;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal"); 
        float deltaZ = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        // Clamp magnitude for diagonal movement
        movement = Vector3.ClampMagnitude (movement, 1.0f);

        // determine how far to move on the XZ plane movement *= speed;
        movement *= speed;

        //gravity is here
        yVelocity += gravity * Time.deltaTime;

        if (cc.isGrounded && yVelocity < 0.0)
        {
            //yVelocity = yVelocityWhenGrounded;
        }

        movement.y = gravity;

        //end gravity

        // Movement code Frame Rate Independent 
        movement *= Time.deltaTime;


        // Convert local to global coordinates 
        movement = transform.TransformDirection(movement);
        cc.Move(movement);


        jumpPress = Input.GetButtonDown("Jump");

        if (jumpPress)
        {
            transform.Translate(Vector3.up, Space.World);
        }
    }

    /*private void FixedUpdate()
    {

    }*/
}