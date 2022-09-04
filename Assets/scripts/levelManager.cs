using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelManager : MonoBehaviour
{
    // Start is called before the first frame update

    Gamelevel curntLvl = null ;
    float currenttime ;
    public int curntlamps;
    Text timer;
    float beft = 0;

    void Start()
    {
        currenttime = 0;
        curntlamps = 0;
        curntLvl = GameManager.Instance.levels[GameManager.Instance.currentLevel];
        currenttime = curntLvl.timer*60;
        timer = GameObject.Find("timer").GetComponent<Text>();
        GameObject.Find("lampscount").GetComponent<Text>().text = (curntLvl.NumOfLamps).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (curntlamps == curntLvl.NumOfLamps )
        {
            Debug.Log("hi");
            GameManager.Instance.currentLevelstatus = true;
            GameManager.Instance.currentLevelScore = (int)((50/curntLvl.NumOfMirrors)+(20*curntlamps)+(100/curntLvl.light)+((1000/(curntLvl.timer))*(currenttime/60)));
            beft += Time.deltaTime;
        }
        if (currenttime < 0)
        {
            GameManager.Instance.currentLevelstatus = false ;
            GameManager.Instance.currentLevelScore = (int)((50 / (curntLvl.NumOfMirrors+1)) + (20 * curntlamps) + (100 /( curntLvl.light+1)));
        }
       
        currenttime -= 1 * Time.deltaTime; 
        timer.text = ((int)currenttime).ToString();
        if (beft > 4)
          GameManager.Instance.ChangeScene("Menu", false);
        //Debug.Log(currenttime);
    }

    public void BackToMenu()
    {
        GameManager.Instance.currentLevel = -1 ;
        GameManager.Instance.ChangeScene("Menu", false);
    }
}
