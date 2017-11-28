using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;

public class MainMenu : MonoBehaviour ///Skrypt obsługujący menu główne
{
	string nick;
	string textLog;
	public Button loginButton;
	Text logText;

	void Start () ///procedura obowiązkowa, wywoływana raz podczas startu aplikacji przez silnik
	{		
		status ();
	}

	// Update is called once per frame
	void Update ()///procedura obowiązkowa, wywoływana cyklicznie co ramkę przez silnik 
	{


		//		if(Input.GetKey("escape")){
		//			Application.Quit ();
		//		}
	}



	public void onClickSzybkaGra()///obsługa przycisku na scenie, tryb "szybka gra"
	{
		SceneManager.LoadScene("quickGame");
		SceneManager.LoadScene("quickGame");
	}

	public void onClickZagrajTime()///obsługa przycisku na scenie, tryb "na czas"
	{
		SceneManager.LoadScene("timeMenu");

	}

	public void onClickZagrajPoints()///obsługa przycisku na scenie, tryb "na punkty"
	{
		SceneManager.LoadScene("pointsMenu");
	}

	public void onClickLogin()///obsługa przycisku na scenie, logowanie
	{	if (!PlayerPrefs.HasKey ("Nick")) 
		{
			SceneManager.LoadScene ("login");
		} 
	else 
	{
		PlayerPrefs.DeleteAll ();
		SceneManager.LoadScene ("mainMenu");
	}
}

	public void onClicZakoncz()///obsługa przycisku na scenie, wyjście z gry
	{
		PlayerPrefs.DeleteAll ();
		Application.Quit ();
	}

	public void status() //procedura obsugująca napis przycsku logowania w zależności od jego stanu
	{		
		loginButton = GameObject.Find ("btnLogin").GetComponent <Button>();
		logText = GameObject.Find ("logText").GetComponent <Text>();

		if (PlayerPrefs.HasKey ("Nick")) 
		{
			nick = "Wyloguj: "+PlayerPrefs.GetString ("Nick");
			textLog = PlayerPrefs.GetString ("Nick")+" teraz możesz zapisywać swoje wyniki w rankingu";
		} 
		else 
		{
			nick = "Zaloguj";
			textLog = "Zaloguj się aby mieć możliwość zapisu swoich wyników do rankingu";
			logText.color = Color.red;
		}
		loginButton.GetComponentInChildren<Text>().text = nick;
		logText.text = textLog;
	}
}
