using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingIguana : MonoBehaviour
{
    private float iguanaSpeed = 3.5f;
    private float obstacleRange = 9.0f;

    private Animator anim;

    private float turn = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = iguanaSpeed;
    }

    private void Move(float turn, float forward) {
        float dampTime = 0.2f;

        if (anim != null) {
            anim.SetFloat("Turn", turn, dampTime, Time.deltaTime);

            anim.SetFloat("Forward", forward, dampTime, Time.deltaTime);
        
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        //determine if we are headed for an obstacle (so we can decide to turn)

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        //test for collision
        if (Physics.SphereCast(ray, 0.5f, out hit)) {

            //is obstacle in the way close enough to warrent a turn?
            if (hit.distance < obstacleRange)
            {

                //if turn value is not set, we decide on left or right turn

                if (Mathf.Approximately(turn, 0.0f))
                {

                    //flip a coin to turn. 0 is left, 1 is right
                    turn = Random.Range(0, 2) == 0 ? -0.75f : 0.75f;
                }


                //blending will cause Iguana to move forward and turn at the same time. Turn quick, move forward slowly.
                Move(turn, 0.1f);

            }
            else
            {//no obstacle, ok to move forward without turn 
                float forwardSpeed = Random.Range(0.05f, 1.0f);
                turn = 0.0f;

                Move(turn, forwardSpeed);
            }
        }



    }
}
