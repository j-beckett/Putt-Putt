using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    //private int score = 0;

    [SerializeField] private TextMeshProUGUI scoreValue;

    [SerializeField] private Image healthBar;

    [SerializeField] private Image crossHair;

    [SerializeField] private OptionsPopup optionsPopup;
    [SerializeField] SettingsPopup settingsPopup;

    private int popupsOpen = 0;
    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.HEALTH_CHANGED, this.OnHealthChanged);
        //Messenger<int>.AddListener(GameEvent.DIFFICULTY_CHANGED, OnDifficultyChanged);
        Messenger.AddListener(GameEvent.POPUP_OPENED, this.OnPopupOpen);      
        Messenger.AddListener(GameEvent.POPUP_CLOSED, this.OnPopupClosed);
        // Messenger.AddListener(GameEvent.GAME_ACTIVE, this.OnPopupClosed);  ///////////////////////////
        //Messenger.AddListener(GameEvent.GAME_INACTIVE, this.OnPopupClosed);  ///////////////////////////
    }
    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.HEALTH_CHANGED, this.OnHealthChanged);
        //Messenger<int>.RemoveListener(GameEvent.DIFFICULTY_CHANGED, OnDifficultyChanged);
        Messenger.RemoveListener(GameEvent.POPUP_OPENED, this.OnPopupOpen);
        Messenger.RemoveListener(GameEvent.POPUP_CLOSED, this.OnPopupClosed);
        // Messenger.RemoveListener(GameEvent.GAME_ACTIVE, this.OnPopupClosed);  ///////////////////////////
        //Messenger.RemoveListener(GameEvent.GAME_INACTIVE, this.OnPopupClosed);  ///////////////////////////
    }

    private void OnHealthChanged(float healthRemaining)
    {
        Debug.Log("HEALTH HAS CHANGED...event... " + healthRemaining.ToString());

        UpdateHealth(healthRemaining);
    }

    void UpdateHealth(float healthPercentage) 
    {
        Color lerpedColor = Color.red;
        lerpedColor = Color.Lerp(Color.red, Color.green, healthPercentage);      
        healthBar.color = lerpedColor;
    }

    void OnPopupOpen() {
        if (popupsOpen == 0) {

            SetGameActive(false);
        }

        popupsOpen++;

        //Debug.Log("popups open: " + popupsOpen);
    }

    void OnPopupClosed() {
        popupsOpen--;

        if (popupsOpen == 0)
        {
            SetGameActive(true);
        }
        //Debug.Log("popups open: " + popupsOpen);
    }

    // Start is called before the first frame update
    void Start()
    {
        /*healthBar.fillAmount = 1; 
        healthBar.color = Color.green;*/

        UpdateHealth(1.0f);

        SetGameActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateScore(score);

        if (Input.GetKeyDown(KeyCode.Escape) && popupsOpen == 0)
        {
            
            optionsPopup.Open();
        }
    }

    public void UpdateScore(int newScore)
    {
        scoreValue.text = newScore.ToString();
    }

    public void SetGameActive(bool active)
    {
        if (active)
        {
            Time.timeScale = 1; // unpause the game
            Cursor.lockState = CursorLockMode.Locked; // show the cursor
            crossHair.gameObject.SetActive(true); // show the crosshair
            Messenger.Broadcast(GameEvent.GAME_ACTIVE);
        }
        else
        {
            Time.timeScale = 0; // pause the game
            Cursor.lockState = CursorLockMode.None; // show the cursor
            crossHair.gameObject.SetActive(false); // turn off the crosshair
            Messenger.Broadcast(GameEvent.GAME_INACTIVE);
        }
    }
}
