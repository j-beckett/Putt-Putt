using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 5;
    }

    // Update is called once per frame
    public void Hit()
    {
        health -= 1;
        Debug.Log("Health is: " + health);

        if (health == 0) {
            Debug.Break();
        }

    }
}
