using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //private static GameManager _instance;
    public static GameManager Instance { get; private set; }
    public  List<Gamelevel> levels;
    public int currentLevel = -1 ;
    public bool currentLevelstatus = false;
    public int currentLevelScore = 0;
    public float soundVolume = 0.472f;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start() {
       levels = new List<Gamelevel>()
        {new Gamelevel(0 ,"Level1", 6f, 2, 3, false , 2),
        new Gamelevel(1,"Level2", 5f, 1, 5, false , 2),
         new Gamelevel(2,"Level3", 4f, 2, 5, false , 1)};
        currentLevel = -1;
        soundVolume = 0.472f;
    }
     
    public  void ChangeScene(string sceneName , bool islevel)
    {
        SceneManager.LoadScene(sceneName);
    }
    enum scene 
    {
        level1,
        level2
    }
}