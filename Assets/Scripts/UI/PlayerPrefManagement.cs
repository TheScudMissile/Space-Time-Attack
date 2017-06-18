using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefManagement : MonoBehaviour
{

	const string BEST_TIME_PHASE = "best_time_phase_";
	const string PHASE_UNLOCK = "phase_";
	const string MARK_UNLOCK_RECORDED = "phase_recorded_";

	public static void SetBestPhase (float recordRawTime, int phaseNum)
	{
		PlayerPrefs.SetFloat (BEST_TIME_PHASE + phaseNum.ToString (), recordRawTime);
	}

	public static float GetBestPhase (int phaseNum)
	{
		return PlayerPrefs.GetFloat (BEST_TIME_PHASE + phaseNum.ToString ());
	}

	public static void UnlockPhase (int phaseNum)
	{
		// no bool, so 1 is true, 0 is false
		PlayerPrefs.SetInt (PHASE_UNLOCK + phaseNum.ToString (), 1);
	}

	public static void LockPhase (int phaseNum)
	{
		PlayerPrefs.SetInt (PHASE_UNLOCK + phaseNum.ToString (), 0);
	}

	public static bool Unlocked (int phaseNum)
	{
		return PlayerPrefs.GetInt (PHASE_UNLOCK + phaseNum.ToString ()) == 1;
	}

	public static void MarkUnlockTextShown (int phaseNum)
	{
		PlayerPrefs.SetInt (MARK_UNLOCK_RECORDED + phaseNum.ToString (), 1);
	}

	public static void UnmarkUnlockTextShown (int phaseNum)
	{
		PlayerPrefs.SetInt (MARK_UNLOCK_RECORDED + phaseNum.ToString (), 0);
	}

	public static bool HasShownUnlockText (int phaseNum)
	{
		return PlayerPrefs.GetInt (MARK_UNLOCK_RECORDED + phaseNum.ToString ()) == 1;
	}
}
