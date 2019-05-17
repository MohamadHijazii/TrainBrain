using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenes : MonoBehaviour
{
    public AudioSource buttonClick;
    public AudioSource music;
    public Button soundBtn;
    public Sprite soundOn;
    public Sprite soundOff;


    private void Start()
    {
        if(soundBtn.image.sprite != null)
            soundBtn.image.sprite = soundOn;
    }
    public void Play()
    {
        SceneManager.LoadScene("GameUI");
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
        SceneManager.LoadScene("Menu");
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
