using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseDone : MonoBehaviour
{
	public Text titleText;
	public Text recordText;
	public Text finalTime;
	public Text phaseUnlocked;

	public static string timeString;
	public static float rawTime;
	public bool bestTime;

	private string phaseNumString;
	private int phaseNum;

	void Start ()
	{
		rawTime = StopWatch.time;
		timeString = StopWatch.Convert (rawTime);
		finalTime = this.GetComponent<Text> ();
		finalTime.text = timeString;

		phaseNum = GameManagement.phaseNum;
		titleText.text = "Phase " + phaseNum + " Complete!";

		bestTime = false;
		HandleFinalTime ();
		Selection.UnlockConditions ();

		bool nextPhaseUnlocked = true;
		int maxPhase = 5;
		int idx = 0;

		for (int i = 2; i <= maxPhase && nextPhaseUnlocked; i++) {
			if (PlayerPrefManagement.Unlocked (i)) {
				idx = i;
			} else {
				nextPhaseUnlocked = false;
			}
		}
		
		if (idx != 0  && !PlayerPrefManagement.HasShownUnlockText (idx)) {
			phaseUnlocked.text = "Phase " + idx + " Unlocked!";
			PlayerPrefManagement.MarkUnlockTextShown (idx);
		} else {
			phaseUnlocked.text = "";
		}
	}

	void HandleFinalTime ()
	{
		if (PlayerPrefManagement.GetBestPhase (phaseNum) == 0 ||
		    PlayerPrefManagement.GetBestPhase (phaseNum) > rawTime) {
			PlayerPrefManagement.SetBestPhase (rawTime, phaseNum);
			bestTime = true;
		}

		if (bestTime) {
			recordText.text = "New Record!";
		} else {
			recordText.text = "";
		}
	}
}
