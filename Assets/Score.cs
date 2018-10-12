using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	void Start () {
		if (GameObject.FindGameObjectWithTag("FinishButton") != null)
		{
			gameObject.GetComponent<Text>().text = "Last Match Score: " + GameObject.FindGameObjectWithTag("FinishButton").GetComponent<GameController>().score;
			Destroy(GameObject.FindGameObjectWithTag("FinishButton"));
		}
	}
	
}
