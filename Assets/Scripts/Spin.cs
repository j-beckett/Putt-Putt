using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    private CharacterController cc;

    [SerializeField]
    private float speed = 10.0f;
    

    [SerializeField]
    private Vector3 rotation;


    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
      // rotation = new Vector3(0, 50, 0) * speed * Time.deltaTime;

        transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);
    }
}
