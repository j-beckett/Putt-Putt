using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsPopup : BasePopup
{
    [SerializeField] OptionsPopup optionsPopup;

    [SerializeField] Slider difficultySlider;

    [SerializeField] TextMeshProUGUI diffLabel;
    override public void Open()
    {
        base.Open();

        difficultySlider.value = PlayerPrefs.GetInt("difficulty", 1);
        UpdateDifficulty(difficultySlider.value);
    }
    override public void Close()
    {
        base.Close();
    }
    override public bool IsActive() {
        return base.IsActive();
    }

    public void SwitchWindows() {

        this.Close();
        optionsPopup.Open();
    }

    public void OnOKButton() {
        PlayerPrefs.SetInt("difficulty", (int)difficultySlider.value);
        Messenger<int>.Broadcast(GameEvent.DIFFICULTY_CHANGED, (int)difficultySlider.value);
        SwitchWindows();
    }
    public void UpdateDifficulty(float difficulty) 
    {
        Debug.Log("UD:" + difficulty);
        diffLabel.text = "Difficulty: " +((int)difficulty).ToString();
    }
    public void OnDifficultyValueChanged(float difficulty) 
    {
        UpdateDifficulty(difficulty);
    }


    // Start is called before the first frame update
    void Start()
    {
        diffLabel.text = "Difficulty: ";
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
