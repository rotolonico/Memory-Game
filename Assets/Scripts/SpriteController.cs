using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteController : MonoBehaviour
{

	public Sprite[] possibleSprites = new Sprite[5];
	public Sprite sprite;
	
	private GameObject finishButton;
	private SpriteRenderer sr;
	
	private int selectedColors;
	private int selectedTime;

	void Start ()
	{
		finishButton = GameObject.FindGameObjectWithTag("FinishButton");
		sr = GetComponent<SpriteRenderer>();
		selectedColors = PlayerPrefs.GetInt("selectedColors", 2)+1;
		selectedTime = PlayerPrefs.GetInt("selectedTime", 1)*5;
		sprite = possibleSprites[Random.Range(1, selectedColors)];
		sr.sprite = sprite;
		StartCoroutine(ReplaceSprites());
	}
	
	IEnumerator ReplaceSprites()
	{
		yield return new WaitForSeconds(selectedTime);
		sr.sprite = possibleSprites[0];
		finishButton.GetComponent<GameController>().replaceSprites = true;
	}
}
