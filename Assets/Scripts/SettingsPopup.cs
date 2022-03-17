using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsPopup : MonoBehaviour
{
    [SerializeField] OptionsPopup optionsPopup;

    [SerializeField] Slider difficultySlider;

    [SerializeField] TextMeshProUGUI diffLabel;
    public void Open()
    {
        gameObject.SetActive(true);

        difficultySlider.value = PlayerPrefs.GetInt("difficulty", 1);
        UpdateDifficulty(difficultySlider.value);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public bool IsActive() { return gameObject.activeSelf; }

    public void SwitchWindows() {

        this.Close();
        optionsPopup.Open();
    }

    public void OnOKButton() {
        PlayerPrefs.SetInt("difficulty", (int)difficultySlider.value);
        SwitchWindows();
    }
    public void UpdateDifficulty(float difficulty) 
    {
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
