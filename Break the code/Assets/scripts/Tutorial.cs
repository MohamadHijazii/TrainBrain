using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Button continueBtn;
    private int count = 0;
    public TextMeshProUGUI screen;
    public Button[] btns;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(count == 7)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void interacte(int n)
    {
        btns[n].interactable = false;
        if(n == 3)
        {
            Debug.Log("ez");
            continueBtn.interactable = true;
            return;
        }
        btns[n + 1].interactable = true;
    }

    public void inc()
    {
        count++;
    }
}
