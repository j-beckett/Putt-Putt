using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePopup : MonoBehaviour
{

    virtual public void Open()
    {
        gameObject.SetActive(true);

        /*difficultySlider.value = PlayerPrefs.GetInt("difficulty", 1);
        UpdateDifficulty(difficultySlider.value);*/
    }
    virtual public void Close()
    {
        gameObject.SetActive(false);
    }
    virtual public bool IsActive()
    {
        return gameObject.activeSelf;
    }
}
