using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteController : MonoBehaviour
{

	public Sprite[] spritePack1 = new Sprite[5];
	public Sprite[] spritePack2 = new Sprite[5];
	public Sprite[] spritePack3 = new Sprite[5];
	public Sprite[] spritePack4 = new Sprite[5];
	public Sprite sprite;
	
	private Sprite[] possibleSprites;
	private GameObject finishButton;
	private GameObject[] color;
	private SpriteRenderer sr;
	
	private int selectedColors;
	private int selectedTime;
	private int selectedTheme;

	void Start ()
	{
		color = GameObject.FindGameObjectsWithTag("Color");
		selectedTheme = PlayerPrefs.GetInt("selectedTheme", 1);
		if (selectedTheme == 1)
		{
			possibleSprites = spritePack1;
		}
		if (selectedTheme == 2)
		{
			possibleSprites = spritePack2;
		}
		if (selectedTheme == 3)
		{
			possibleSprites = spritePack3;
		}
		if (selectedTheme == 4)
		{
			possibleSprites = spritePack4;
		}

		for (int i = 0; i < color.Length; i++)
		{
			color[i].GetComponent<SpriteRenderer>().sprite = possibleSprites[i+1];
		}
		
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
