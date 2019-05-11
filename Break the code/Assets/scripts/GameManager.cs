using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public Button []btns;
    public int[] num;
    public int[] choice;
    public int index;
    public int N;
    public Text screen;  
    public TextMeshProUGUI res;
    public Transform pan;
    public TextMeshProUGUI result;
    public GameObject winPanel;

    void Start()
    {
        N = 4;
        index = N-1;
        screen.text = "";
        result.text = "";
        winPanel.SetActive(false);
        choice = new int[N];        
        for(int i = 0; i < 9; i++)
        {
            int c = i;
            btns[i].GetComponentInChildren<Text>().text = (c+1) + "";
            btns[i].onClick.AddListener(() => changeNumber(c+1));
        }
        generateNumber(N);
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad1))
            changeNumber(1);
        if (Input.GetKey(KeyCode.Keypad2))
            changeNumber(2);
        if (Input.GetKey(KeyCode.Keypad3))
            changeNumber(3);
        if (Input.GetKey(KeyCode.Keypad4))
            changeNumber(4);
        if (Input.GetKey(KeyCode.Keypad5))
            changeNumber(5);
        if (Input.GetKey(KeyCode.Keypad6))
            changeNumber(6);
        if (Input.GetKey(KeyCode.Keypad7))
            changeNumber(7);
        if (Input.GetKey(KeyCode.Keypad8))
            changeNumber(8);
        if (Input.GetKey(KeyCode.Keypad9))
            changeNumber(9);
        if (Input.GetKey(KeyCode.KeypadEnter))
            comp();
        if (Input.GetKey(KeyCode.Keypad0) || Input.GetKey(KeyCode.C))
            clear();

    }

    public void changeNumber(int n) {
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
        if (index > 0)
            return;
        if (win()) {
            afterWin();
        }
        string new_data = "";
        new_data += arToString_R(choice);
        new_data += "  ";
        new_data += compare();
        result.text = new_data + "\n"+ result.text;
        

    }

    public void generateNumber(int n) {
        num = new int[n];
        ini(num);
        int index = n;
        int temp;
        while ((index--) != 0) {
            do
            {
                temp = Random.Range(1, 9);
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
    }


    public void restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
