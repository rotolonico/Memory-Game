using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
	private int selectedColors;
	private int selectedTime;
	private GameObject settingsText;

	void Start()
	{
		selectedColors = PlayerPrefs.GetInt("selectedColors", 2);
		selectedTime = PlayerPrefs.GetInt("selectedTime", 1);
		settingsText = GameObject.FindGameObjectWithTag("Text2");
	}
	
	void Update()
	{
		if (Input.GetMouseButtonDown(0)) {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
			if (hit.collider != null)
			{
				if (hit.collider.CompareTag("start"))
				{
					SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
				}
				if (hit.collider.CompareTag("colors"))
				{
					selectedColors++;
					if (selectedColors == 5)
					{
						selectedColors = 2;
					}
					PlayerPrefs.SetInt("selectedColors", selectedColors);
					settingsText.GetComponent<Text>().text = "Colors are now " + selectedColors;
				}
				if (hit.collider.CompareTag("time"))
				{
					selectedTime++;
					if (selectedTime == 5)
					{
						selectedTime = 1;
					}
					PlayerPrefs.SetInt("selectedTime", selectedTime);
					settingsText.GetComponent<Text>().text = "Memorizing time is now " + selectedTime*5 + " seconds";
				}
			}
		}
	}
}
