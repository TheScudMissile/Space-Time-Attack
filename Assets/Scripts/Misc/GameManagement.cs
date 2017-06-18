using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagement : MonoBehaviour
{
	public Ship ship;

	private GameObject wall;
	private GameObject pauseMenu;
	private char[] currSceneName;
	public static int phaseNum;
	private bool paused;
	private float timeScaleForGame;

	void Start ()
	{
		currSceneName = SceneManager.GetActiveScene ().name.ToCharArray ();

		if (currSceneName.Length >= 6 && (currSceneName [5] == '1' ||
		    currSceneName [5] == '2' || currSceneName [5] == '3' ||
		    currSceneName [5] == '4' || currSceneName [5] == '5')) {

			phaseNum = int.Parse (currSceneName [5].ToString ());
		}

		ship = FindObjectOfType<Ship> ();
		wall = GameObject.FindGameObjectWithTag ("Wall");

		paused = false;
		pauseMenu = GameObject.FindGameObjectWithTag ("Pause");

		if (pauseMenu) {
			pauseMenu.SetActive (false);
		}
		timeScaleForGame = Time.timeScale;
	}

	void Update ()
	{
		if (!ship && wall) {
			Invoke ("Restart", 2f);
		}
	}

	public void PauseGame ()
	{
		paused = true;
		pauseMenu.SetActive (paused);
		Time.timeScale = 0;
	}

	public void ResumeGame ()
	{
		paused = false;
		pauseMenu.SetActive (paused);
		Time.timeScale = timeScaleForGame;
	}

	public void LoadLevel (string name)
	{
		if (name == "Menu") {
			Time.timeScale = timeScaleForGame;
			StopWatch.Reset ();
		} else if (name.Contains ("Phase")) {
			StopWatch.playing = true;
		}

		SceneManager.LoadScene (name);
	}

	public void LoadUnlockedLevel (int phaseNum)
	{
		if (PlayerPrefManagement.Unlocked (phaseNum)) {
			LoadLevel ("Phase" + phaseNum + "_01");
		}
	}

	public static void LoadNext ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void Restart ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void EraseAllData ()
	{
		PlayerPrefManagement.SetBestPhase (0, 1);

		for (int i = 2; i <= 5; i++) {
			PlayerPrefManagement.SetBestPhase (0, i);
			PlayerPrefManagement.LockPhase (i);
			PlayerPrefManagement.UnmarkUnlockTextShown (i);
		}
		LoadLevel ("Menu");
	}
}
