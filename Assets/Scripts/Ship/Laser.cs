﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
	public void Hit ()
	{
		Destroy (gameObject);
	}
}
