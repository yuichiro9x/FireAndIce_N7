using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;


public class GameMode : MonoBehaviour
{
    public int numberOfKey = 3;
    private float currentTime;
    bool isGameEnd;
    int _numKeys;
    
    // Start is called before the first frame update
    void Start()
    {
        _numKeys = 0;
        isGameEnd = false;
        currentTime = 0;
        Thread time = new Thread(() => {
            TimeCal();            
        });
        time.Start();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_numKeys >= numberOfKey)
        {
            isGameEnd = true;
            Debug.Log(getCurrentTime());
        }
    }
    public void ResetGame()
    {

        //currentTime = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name.ToString());
        //Application.LoadLevel(Application.loadedLevel);
    }

    void TimeCal()
    {
        while (!isGameEnd)
        {
            Thread.Sleep(1000);
            currentTime++;
        }
        
    }

    public string getCurrentTime()
    {
        //float Min;
        float Sec;
        double Min;
        Min = System.Math.Truncate(currentTime / 60);
        Sec = currentTime % 60;
        string time= (Min.ToString()+" : "+Sec.ToString());
        return (time);
    }

    public string getNumKeys()
    {
        return _numKeys.ToString();
    }
    
    public void setNumKey()
    {
        _numKeys++;
        Debug.Log(_numKeys);
    }
}
