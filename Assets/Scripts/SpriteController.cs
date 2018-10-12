using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteController : MonoBehaviour
{

	public Sprite[] possibleSprites = new Sprite[5];
	public Sprite sprite;
	
	private GameObject[] finishButton;
	private SpriteRenderer sr;
	
	private int selectedColors;
	private int time = 10;

	void Start ()
	{
		finishButton = GameObject.FindGameObjectsWithTag("FinishButton");
		sr = GetComponent<SpriteRenderer>();
		selectedColors = possibleSprites.Length;
		sprite = possibleSprites[Random.Range(1, selectedColors)];
		sr.sprite = sprite;
		StartCoroutine(ReplaceSprites());
	}
	
	IEnumerator ReplaceSprites()
	{
		yield return new WaitForSeconds(time);
		sr.sprite = possibleSprites[0];
		finishButton[0].GetComponent<GameController>().replaceSprites = true;
	}
}
