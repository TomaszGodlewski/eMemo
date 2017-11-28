using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimeMenu : MonoBehaviour ///Skrypt obsługujący menu wyboru tablicy gry dla trybu "na czas"
{ 

	// Use this for initialization
	void Start () ///procedura obowiązkowa, wywoływana raz podczas startu aplikacji przez silnik
	{
	
	}
	
	// Update is called once per frame
	void Update () ///procedura obowiązkowa, wywoływana cyklicznie co ramkę przez silnik
	{
	
	}

	public void onClick4x4() ///obsługa przycisku na scenie, wielkosc tablicy 4x4
	{
		SceneManager.LoadScene("time4x4");
		SceneManager.LoadScene("time4x4");
	}

	public void onClick4x5()///obsługa przycisku na scenie, wielkosc tablicy 4x5
	{
		SceneManager.LoadScene("time4x5");
		SceneManager.LoadScene("time4x5");
	}

	public void onClick4x6()///obsługa przycisku na scenie, wielkosc tablicy 4x6
	{
		SceneManager.LoadScene ("time4x6");
		SceneManager.LoadScene ("time4x6");
	}
		
	public void onClickPowrot()///obsługa przycisku na scenie, powrot do glownego menu
	{
			SceneManager.LoadScene("mainMenu");

	}
}
