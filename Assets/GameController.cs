using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	
	private GameObject[] followMouse;
	private GameObject[] tiles;
	
	private Sprite selectedSprite;
	
	public int score;
	public bool replaceSprites;

	private void Start()
	{
		DontDestroyOnLoad(gameObject);
		followMouse = GameObject.FindGameObjectsWithTag("Mouse");
		tiles = GameObject.FindGameObjectsWithTag("Tile");
	}

	void Update () {
		if (SceneManager.GetActiveScene().buildIndex == 1)
		{
			followMouse[0].GetComponent<Rigidbody2D>().position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}

		if (replaceSprites)
		{
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
						followMouse[0].GetComponent<SpriteRenderer>().sprite = selectedSprite;
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
