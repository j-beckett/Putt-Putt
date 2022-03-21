using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPopup : BasePopup
{
    [SerializeField] UIController uIController;


    [SerializeField] SettingsPopup settingsPopup;
    override public void Open()
    {
        base.Open();
    }
    override public void Close()
    {
        base.Close();
    }
    override public bool IsActive() {
        return base.IsActive();
    }
    public void OnSettingsButton()
    {
        Debug.Log("settings clicked");
        this.Close();
        settingsPopup.Open();
    }
    public void OnExitGameButton()
    {
        Debug.Log("exit game");
        Application.Quit();
    }
    public void OnReturnToGameButton()
    {
        Debug.Log("return to game"); Close();

        uIController.SetGameActive(true);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
