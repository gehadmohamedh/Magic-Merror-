using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class UIController : MonoBehaviour
{
	AudioSource sound;
	public Slider soundSlider ;
	bool currentLevelstatus;
	public void ChangeScene(int LevelID)
	{
		GameManager.Instance.currentLevel = LevelID;
		string sceneName = "Level"+(LevelID + 1).ToString();
		SceneManager.LoadScene(sceneName);
	}
	public void Exit()
	{
		Application.Quit();
	}
	public void Soundcontroller()
	{
		Debug.Log("hiii");
	
	}
	private void Start()
	{
		
		sound = GameManager.Instance.GetComponent<AudioSource>() ;
		sound.GetComponent<AudioSource>().playOnAwake = true;
		Debug.Log("hereeeeee");
		soundSlider.value = GameManager.Instance.soundVolume;

		// if we call score menu 
		if (GameManager.Instance.currentLevel != -1)
		{
			GameObject.Find("MainMenu").SetActive(false);
			GameObject.Find("Settings").SetActive(false);
			GameObject.Find("LevelsMenu").SetActive(false);
			GameObject.Find("TutorialMenu").SetActive(false);
			GameObject.Find("ScoreMenu").SetActive(true);
			currentLevelstatus = GameManager.Instance.currentLevelstatus;
			Gamelevel currentlevl = GameManager.Instance.levels[GameManager.Instance.currentLevel];
			TextMeshProUGUI status = GameObject.Find("LevelStatus").GetComponent<TextMeshProUGUI>();
			TextMeshProUGUI score = GameObject.Find("scoreVal").GetComponent<TextMeshProUGUI>();
			TextMeshProUGUI nextstep = GameObject.Find("Nextleveltxt").GetComponent<TextMeshProUGUI>();
			score.text =GameManager.Instance.currentLevelScore.ToString() + "/" + currentlevl.score.ToString();
			if (currentLevelstatus == true)
			{
				status.text = "LEVEL PASSED";
				status.color = Color.green;
				nextstep.text = "Next Level";
			}
			else
			{
				status.text = "LEVEL FAILD";
				status.color = Color.red;
				nextstep.text = "Restart";
			}
		}
		else
		{
			GameObject.Find("ScoreMenu").SetActive(false);
			GameObject.Find("Settings").SetActive(false);
			GameObject.Find("LevelsMenu").SetActive(false);
			GameObject.Find("TutorialMenu").SetActive(false);
		}
	}
	private void Update()
	{
		
	}
	public void Nextstep()
	{
		if (currentLevelstatus)
		{
			GameManager.Instance.currentLevel++;
			GameManager.Instance.currentLevelstatus = false;
		}
	    GameManager.Instance.ChangeScene(GameManager.Instance.levels[GameManager.Instance.currentLevel].name, true);
	}
	public void soundVolume()
	{
		if (soundSlider)
		{
			sound.GetComponent<AudioSource>().volume = soundSlider.value;
			GameManager.Instance.soundVolume = soundSlider.value;
		}
	}
}