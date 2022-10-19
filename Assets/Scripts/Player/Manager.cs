using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Manager : MonoBehaviour
{
    public static Manager instance;

    public int cherryScore;
    public int gemScore;
    public Text textCherry;
    public Text textGem;

  
    public void Awake()
    {
        
        textCherry.text = cherryScore.ToString();
        textGem.text = gemScore.ToString();
        instance = this;
        DontDestroyOnLoad(this);
        textGem.text = gemScore.ToString();
    }
     void Start()
    {
        //StartCoroutine(AfterSecond());
        

    }
    IEnumerator AfterSecond()
    {
        yield return new WaitForSeconds(5);
        Pause();
    }
    public void Pause()
    {

        Time.timeScale = 0;
    }
    public void Continue()
    {
        Time.timeScale = 1;
    }
    public void ComeBack()
    {
        SceneManager.LoadScene(0);
    }



}
