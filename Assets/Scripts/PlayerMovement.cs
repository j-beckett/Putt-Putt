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

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    
    }

    // Update is called once per frame
    void Update()
    {
        xMovement = Input.GetAxis("Horizontal");

        zMovement = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(xMovement, 0, zMovement) * Time.deltaTime * speed ;

        cc.transform.Translate(move);

        //transform.Translate(move);
    }

    /*private void FixedUpdate()
    {
       
    }*/
}