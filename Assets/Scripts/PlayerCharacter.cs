using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int health;
    private int maxHealth = 5;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    public void Hit()
    {
       /* Messenger<int>.Broadcast(GameEvent.DIFFICULTY_CHANGED, (int)difficultySlider.value);*/
        float healthRemaining = (float)health / (float)maxHealth;
        Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, healthRemaining);
        health -= 1;
        Debug.Log("Health is: " + health);

        if (health == 0) {
            Debug.Break();
        }

    }
}
