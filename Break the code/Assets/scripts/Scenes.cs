using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Scenes : MonoBehaviour
{
    public AudioSource buttonClick;
    public AudioSource music;
    public Button soundBtn;
    public Sprite soundOn;
    public Sprite soundOff;
    public static int bestScore;
    public TextMeshProUGUI bs;

    private void Start()
    {
        
        //PlayerPrefs.SetInt("bestScori", 10000);
        bestScore = PlayerPrefs.GetInt("bestScori",10000);
        if (bestScore == 10000)
        {
            bs.text = "NO";

        }
        else
            bs.text = bestScore.ToString();

        if (soundBtn.image.sprite != null)
            soundBtn.image.sprite = soundOn;
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void menu() {
        SceneManager.LoadScene(0);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void switchSound()
    {
        buttonClick.mute = !buttonClick.mute;
        music.mute = !music.mute;
        if (soundBtn.image.sprite.Equals(soundOn))        
            soundBtn.image.sprite = soundOff;        
        else
            soundBtn.image.sprite = soundOn;

    }
}
