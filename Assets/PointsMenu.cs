using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PointsMenu : MonoBehaviour ///Skrypt obsługujący menu wyboru tablicy gry dla trybu "na punkty"
{ 

	// Use this for initialization
	void Start () ///procedura obowiązkowa, wywoływana raz podczas startu aplikacji przez silnik
	{
	
	}
	
	// Update is called once per frame
	void Update () ///procedura obowiązkowa, wywoływana cyklicznie co ramkę przez silnik
	{
	
	}

	public void onClick4x4()///obsługa przycisku na scenie, wielkosc tablicy 4x4
	{
		SceneManager.LoadScene("points4x4");
		SceneManager.LoadScene("points4x4");
	}

	public void onClick4x5()///obsługa przycisku na scenie, wielkosc tablicy 4x5
	{
		SceneManager.LoadScene("points4x5");
		SceneManager.LoadScene("points4x5");
	}

	public void onClick4x6()///obsługa przycisku na scenie, wielkosc tablicy 4x6
	{
		SceneManager.LoadScene ("points4x6");
		SceneManager.LoadScene ("points4x6");
	}
		
	public void onClickPowrot()///obsługa przycisku na scenie, wyjście do głównego menu
	{
			SceneManager.LoadScene("mainMenu");

	}
}
