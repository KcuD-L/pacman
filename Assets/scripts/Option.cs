using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public AudioSource audio;
    public GameObject BG;
    public Slider SondSlider;

    public void OpenMenuTab()
    {
        if (Time.timeScale != 0.1f)
        {
            Time.timeScale = 0.1f;
            BG.SetActive(true);
        }
    }
    public void CloseMenuTab()
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
            BG.SetActive(false);
        }
    }

    private void Update()
    {
        audio.volume = SondSlider.value*0.5f;
        Debug.Log(SondSlider.value);
    }
}
