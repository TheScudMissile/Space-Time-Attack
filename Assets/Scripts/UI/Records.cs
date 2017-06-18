using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Records : MonoBehaviour
{
	public Text P1;
	public Text P2;
	public Text P3;
	public Text P4;
	public Text P5;

	// Use this for initialization
	void Start ()
	{
		P1.text = StopWatch.Convert (PlayerPrefManagement.GetBestPhase (1));
		P2.text = StopWatch.Convert (PlayerPrefManagement.GetBestPhase (2));		
		P3.text = StopWatch.Convert (PlayerPrefManagement.GetBestPhase (3));		
		P4.text = StopWatch.Convert (PlayerPrefManagement.GetBestPhase (4));		
		P5.text = StopWatch.Convert (PlayerPrefManagement.GetBestPhase (5));		
	}
}
