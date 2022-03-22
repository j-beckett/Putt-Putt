using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
   

    // enum to set values by name instead of number. // makes code more readable!
    public enum RotationAxes { MouseXAndY, MouseX, MouseY }

    // public class-scope variable so it shows up in Inspector

    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHoriz = 9.0f;


    public float sensitivityVert = 9.0f;
    public float minVert = -45.0f;
    public float maxVert = 45.0f; 
    private float rotationX = 0.0f;

    private bool isActive = true;
    // Start is called before the first frame update

    void Awake()
    {
        Messenger.AddListener(GameEvent.GAME_ACTIVE, this.OnGameActive);  ///////////////////////////
        Messenger.AddListener(GameEvent.GAME_INACTIVE, this.OnGameInActive);  ///////////////////////////
    }
    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.GAME_ACTIVE, this.OnGameActive);  ///////////////////////////
        Messenger.RemoveListener(GameEvent.GAME_INACTIVE, this.OnGameInActive);  ///////////////////////////
    }


    void Start()
    {
      
    }

    void OnGameActive() {
        isActive = true;
    }

    void OnGameInActive() {

        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if (axes == RotationAxes.MouseX)
            {
                // horizontal rotation here
                transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * sensitivityHoriz);
            }
            else if (axes == RotationAxes.MouseY)
            {
                rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
                rotationX = Mathf.Clamp(rotationX, minVert, maxVert);

                transform.localEulerAngles = new Vector3(rotationX, 0, 0);
            }

            else
            {
                rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
                rotationX = Mathf.Clamp(rotationX, minVert, maxVert);

                float deltaHoriz = Input.GetAxis("Mouse X") * sensitivityHoriz;
                float rotationY = transform.localEulerAngles.y + deltaHoriz;

                transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);

            }
        }


}
}
