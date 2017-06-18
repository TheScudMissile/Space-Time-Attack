using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
	public Text locked_2;
	public Text locked_3;
	public Text locked_4;
	public Text locked_5;

	public static bool Unlocked_2;
	public static bool Unlocked_3;
	public static bool Unlocked_4;
	public static bool Unlocked_5;

	public static float best1;
	public static float best2;
	public static float best3;
	public static float best4;

	void Start ()
	{
		UnlockConditions ();

		Text[] lockedTexts = { locked_2, locked_3, locked_4, locked_5 };

		for (int i = 0; i < lockedTexts.Length; i++) {
			if (PlayerPrefManagement.Unlocked (i + 2)) {
				lockedTexts [i].text = "";
			}
		}
	}

	public static void UnlockConditions ()
	{
		best1 = PlayerPrefManagement.GetBestPhase (1);
		best2 = PlayerPrefManagement.GetBestPhase (2);
		best3 = PlayerPrefManagement.GetBestPhase (3);
		best4 = PlayerPrefManagement.GetBestPhase (4);

        Unlocked_2 = best1 < 180f && best1 != 0;

		Unlocked_3 = best1 < 170f && best1 != 0 &&
		best2 < 330f && best2 != 0; 

		Unlocked_4 = best1 < 160f && best1 != 0 &&
		best2 < 315f && best2 != 0 &&
		best3 < 420f && best3 != 0;

		Unlocked_5 = best1 < 150f && best1 != 0 &&
		best2 < 300f && best2 != 0 &&
		best3 < 400f && best3 != 0 &&
		best4 < 480f && best4 != 0;

		bool[] Unlocked = { Unlocked_2, Unlocked_3, Unlocked_4, Unlocked_5 };

		for (int i = 0; i < Unlocked.Length; i++) {
			if (Unlocked [i]) {
				PlayerPrefManagement.UnlockPhase (i + 2);
			}
		}
	}
}