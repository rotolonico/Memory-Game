using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	void Start () {
		if (GameObject.FindGameObjectWithTag("FinishButton") != null)
		{
			gameObject.GetComponent<Text>().text = "You got " + GameObject.FindGameObjectWithTag("FinishButton").GetComponent<GameController>().score + "/16 tiles right!";
			Destroy(GameObject.FindGameObjectWithTag("FinishButton"));
		}
	}
	
}
