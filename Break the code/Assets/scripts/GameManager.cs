using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int sceneType;

    public Button []btns;
    int[] num;
    int[] choice;
    int index;
    int N;
    public TextMeshProUGUI screen;  
    public TextMeshProUGUI res;
    public GameObject pan;
    public TextMeshProUGUI result;
    public GameObject winPanel;
    public AudioSource click;
    public AudioClip clip;
    public TextMeshProUGUI tries;
    int t;

    void Start()
    {
        N = 4;
        index = N-1;
        screen.text = "";
        result.text = "";
        winPanel.SetActive(false);
        choice = new int[N];
        t = 0;
        for(int i = 0; i < 9; i++)
        {
            int c = i+1;
            //btns[i].GetComponentInChildren<Text>().text = (c + 1) + "";
            btns[i].onClick.AddListener(() => changeNumber(c));

        }
        generateNumber(N);
        Debug.Log(arToString_R(num));
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
            changeNumber(1);
        if (Input.GetKeyDown(KeyCode.Keypad2))
            changeNumber(2);
        if (Input.GetKeyDown(KeyCode.Keypad3))
            changeNumber(3);
        if (Input.GetKeyDown(KeyCode.Keypad4))
            changeNumber(4);
        if (Input.GetKeyDown(KeyCode.Keypad5))
            changeNumber(5);
        if (Input.GetKeyDown(KeyCode.Keypad6))
            changeNumber(6);
        if (Input.GetKeyDown(KeyCode.Keypad7))
            changeNumber(7);
        if (Input.GetKeyDown(KeyCode.Keypad8))
            changeNumber(8);
        if (Input.GetKeyDown(KeyCode.Keypad9))
            changeNumber(9);
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
            comp();
        if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.C))
            clear();

    }

    public void changeNumber(int n) {
        click.PlayOneShot(clip);    
        if (belong(choice, n))
            return;
        if (index < 0)
            return;
        choice[index--] = n;
        screen.text = arToString_R(choice);
    }

    public void clear()
    {
        screen.text = "";
        index = N - 1;
        ini(choice);
    }

    public string compare()
    {
        string res = "";
        screen.text = "";
        index = N-1;
        
        int stars = getStars();
        for(int i = 0; i < stars; i++)
        {
            res += "*";
        }
        int points = getPoints();
        for (int i = 0; i < points; i++)
        {
            res += ".";
        }
        ini(choice);
        return res;
    }
    public void comp() {
        if (index >= 0)
            return;
        
        if (win()) {
            afterWin();
        }
        string new_data = "";
        new_data += arToString_R(choice);
        new_data += "  ";
        new_data += compare();
        result.text = new_data + "\n"+ result.text;
        t++;
        tries.text = t.ToString();

    }

    public void generateNumber(int n) {
        num = new int[n];
        ini(num);
        int index = n;
        int temp;
        while ((index--) != 0) {
            do
            {
                temp = Random.Range(1, 10);
                //num[index] = temp;

            } while (belong(num, temp));
            num[index] = temp;
        }
    }

    private bool belong(int []ar,int n) {
        for(int i = 0; i < ar.Length; i++)
        {
            if (ar[i] == n)
                return true;
        }
        return false;
    }

    private void ini(int []ar)
    {
        for(int i = 0; i < ar.Length; i++)
        {
            ar[i] = 0;
        }
    }

    private string arToString(int[] ar)
    {
        string s = "";
        for(int i = 0; i < ar.Length; i++)
        {
            if(ar[i]!=0)
                s += ar[i];
        }
        return s;
    }

    private string arToString_R(int[] ar)
    {
        string s = "";
        for(int  i = ar.Length-1;i>=0 ; i--)
        {
            if (ar[i] != 0)
                s += ar[i];
        }
        return s;
    }

    private bool point(int v,int pos,int []ar)
    {
        for(int i=0;i<ar.Length; i++)
        {
            if (v == ar[i] && i!=pos)
                return true;
        }
        return false;

    }

    private bool star(int v,int pos,int[] ar)
    {
        return ar[pos] == v;
    }

    private int getStars()
    {
        int count = 0;
        for(int i = 0; i < N; i++)
        {
            if (star(choice[i], i, num))
            {
                count++;
            }
        }
        return count;
    }

    private int getPoints()
    {
        int count = 0;
        for (int i = 0; i < N; i++)
        {
            if (point(choice[i], i, num)) {

                count++;}
        }
        return count;
    }

    private bool win() {
        return getStars() == 4;
    }

    private void afterWin() {
        winPanel.SetActive(true);
        result.enabled = false;
        pan.SetActive(false);
        if(Scenes.bestScore > t)
        {
            PlayerPrefs.SetInt("bestScori", t);
        }
    }

}
