using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
	public AudioSource audioClick;
	public AudioClip audioClickClip;
	
	private int selectedColors;
	private int selectedTime;
	private int selectedTheme;
	private GameObject settingsText;
	private static int ShopPoints;

	void Start()
	{
		audioClick.clip = audioClickClip;
		selectedColors = PlayerPrefs.GetInt("selectedColors", 2);
		selectedTime = PlayerPrefs.GetInt("selectedTime", 1);
		selectedTheme = PlayerPrefs.GetInt("selectedTheme", 1);
		settingsText = GameObject.FindGameObjectWithTag("Text2");
		loadPoints();
		savePoints();
	}
	
	public void savePoints() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create (Application.persistentDataPath + "/saves.s");
        bf.Serialize(file, ShopPoints);
        file.Close();
	}
	
	public void loadPoints() {
		if(File.Exists(Application.persistentDataPath + "/saves.s")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/saves.s", FileMode.Open);
			ShopPoints = (int)bf.Deserialize(file);
			file.Close();
		}
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
					audioClick.Play();
					SceneManager.LoadScene(1);
				}
				if (hit.collider.CompareTag("shop"))
				{
					audioClick.Play();
					settingsText.GetComponent<Text>().text = "Coming soon...";
					// SceneManager.LoadScene(2);
				}
				if (hit.collider.CompareTag("colors"))
				{
					audioClick.Play();
					selectedColors++;
					if (selectedColors == 5)
					{
						selectedColors = 2;
					}
					PlayerPrefs.SetInt("selectedColors", selectedColors);
					settingsText.GetComponent<Text>().text = "Items are now " + selectedColors;
				}
				if (hit.collider.CompareTag("time"))
				{
					audioClick.Play();
					selectedTime++;
					if (selectedTime == 5)
					{
						selectedTime = 1;
					}
					PlayerPrefs.SetInt("selectedTime", selectedTime);
					settingsText.GetComponent<Text>().text = "Memorizing time is now " + selectedTime*5 + " seconds";
				}
				if (hit.collider.CompareTag("themes"))
				{
					audioClick.Play();
					selectedTheme++;
					if (selectedTheme == 5)
					{
						selectedTheme = 1;
					}
					PlayerPrefs.SetInt("selectedTheme", selectedTheme);
					if (selectedTheme == 1)
					{
						settingsText.GetComponent<Text>().text = "Theme is now colors";
					}
					if (selectedTheme == 2)
					{
						settingsText.GetComponent<Text>().text = "Theme is now shapes";
					}
					if (selectedTheme == 3)
					{
						settingsText.GetComponent<Text>().text = "Theme is now numbers";
					}
					if (selectedTheme == 4)
					{
						settingsText.GetComponent<Text>().text = "Theme is now letters";
					}
				}
				if (hit.collider.CompareTag("exit"))
				{
					audioClick.Play();
					Application.Quit();
				}
				if (hit.collider.CompareTag("resetGame"))
				{
					audioClick.Play();
					ShopPoints = 0;
					savePoints();
					PlayerPrefs.DeleteAll();
					settingsText.GetComponent<Text>().text = "Game and settings have been reset";
				}
			}
		}
	}
}
