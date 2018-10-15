using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	
	private GameObject followMouse;
	private GameObject[] tiles;
	private bool gong;
	
	private Sprite selectedSprite;
	
	public int score;
	public bool replaceSprites;
	public AudioSource clockSound;
	public AudioSource gongSound;
	public AudioClip gongClip;

	private void Start()
	{
		DontDestroyOnLoad(gameObject);
		followMouse = GameObject.FindGameObjectWithTag("Mouse");
		tiles = GameObject.FindGameObjectsWithTag("Tile");
		gongSound.clip = gongClip;
	}

	void Update () {
		if (SceneManager.GetActiveScene().buildIndex == 1)
		{
			followMouse.GetComponent<Rigidbody2D>().position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}

		if (replaceSprites)
		{
			if (!gong)
			{
				gongSound.Play();
				clockSound.Stop();
				gong = true;
			}
			
			if (Input.GetMouseButtonDown(0))
			{
				Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
				RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
				if (hit.collider != null)
				{
					if (hit.collider.CompareTag("Color"))
					{
						selectedSprite = hit.collider.GetComponent<SpriteRenderer>().sprite;
						followMouse.GetComponent<SpriteRenderer>().sprite = selectedSprite;
					}

					if (hit.collider.CompareTag("Tile"))
					{
						if (selectedSprite != null)
						{
							hit.collider.GetComponent<SpriteRenderer>().sprite = selectedSprite;
						}
					}

					if (hit.collider.CompareTag("FinishButton"))
					{
						foreach (var i in tiles)
						{
							if (i.GetComponent<SpriteController>().sprite == i.GetComponent<SpriteRenderer>().sprite)
							{
								score++;
							}
						}
						SceneManager.LoadScene(0);
					}
				}
			}
		}
	}
}
