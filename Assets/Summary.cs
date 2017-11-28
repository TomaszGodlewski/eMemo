using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Summary : MonoBehaviour ///skrypt obsługujący podsumowanie rozgrywki w trybach "na czas" i "na punkty"
{ 

	HSController comm = new HSController ();

	string nick; ///pole zawierające nick gracza
	int movesCounter; ///pole zawierające liczbę ruchów
	int pointsCounter; ///pole zawierające liczbę punktów
	float timer; ///pole zawierające czas rozgrywki
	int tabSize; ///pole zawierające wielkość tablicy
	string timeMode; ///pole zawierające tryb gry zapisana jako wartość boolowska

	string currentMode; ///nazwa trybu gry np na czas
	int currentTabSize; ///wielkość tablicy gry do wysłania do bazy danych np 44
	string tabSizeName; ///wielkość tablicy gry do wysłania do bazy danych np 4x4

	private Text mode; ///obsługa tekstu trybu gry w inspektorze
	private Text endGameText; ///obsługa tekstu w inspektorze
	private Text timePointMoves; ///obsługa wyświetlania upływu czasu w inspektorze
	private Text saveTextMsg;///obsługa wyświetlania stanu zapisu w inspektorze

	// Use this for initialization
	void Start () ///procedura obowiązkowa, wywoływana raz podczas startu aplikacji przez silnik
	{		
		playerNick ();
		loadSaves ();
		currentStates ();
		Debug.Log ("Summary Timer: " + timer);
		Debug.Log ("Summary movesCounter: " + movesCounter);
		Debug.Log ("Summary TabSize: " + tabSize);
		Debug.Log ("Summary timeMode: " + timeMode);
		movesCounterText ();
		timePointMovesText ();
		modeText ();	
		saveTextStatus ();
	}
	
	// Update is called once per frame
	void Update () ///procedura obowiązkowa, wywoływana cyklicznie co ramkę przez silnik
	{
		if(Input.GetKey("escape")){
			Application.Quit ();
		}
	}

	public void onClickNie()///obsługa przycisku na scenie, bez zapisu do systemu rankingowego
	{
		PlayerPrefs.DeleteKey ("Moves");
		PlayerPrefs.DeleteKey ("Points");
		PlayerPrefs.DeleteKey ("TabSize");
		PlayerPrefs.DeleteKey ("Mode");
		PlayerPrefs.DeleteKey ("Time");
		SceneManager.LoadScene("mainMenu");
	}



	public void onClicTak()///obsługa przycisku na scenie, zapis do systemu rankingowego
	{
		if (nick != "null") 
		{
			StartCoroutine (comm.PostScores (timer, movesCounter, pointsCounter, nick, currentTabSize, currentMode));
		} 
		else 
		{
			SceneManager.LoadScene ("nullName");
		}

	}


	public void loadSaves()///ładowanie zapisanych stanów rozgrywki:liczba ruchów, punktów, czas rozgrywki, wielkość tablicy gry
	{		
		movesCounter = PlayerPrefs.GetInt ("Moves");
		pointsCounter = PlayerPrefs.GetInt ("Points");
		timer = PlayerPrefs.GetFloat ("Time");
		tabSize = PlayerPrefs.GetInt ("TabSize");
		timeMode = PlayerPrefs.GetString ("Mode");
	}

	void movesCounterText()///procedura wyświetlająca liczbę punktów
	{		
		endGameText = GameObject.Find ("endGameText").GetComponent<Text> (); //wyszukiwanie pola tekstowego "countText", obsługującego wyświetlanie licznika ruchów
		if ((timeMode == "True")||((timeMode=="False")&&(timer>0.0))) 
		{
			endGameText.text = "Tablica została ułożona!";
		}
		if (timeMode == "False"&&timer<=0.0) 
		{
			endGameText.text = "Czas się skończył!";
		}

	}

	private void timePointMovesText()///procedura wyświetlająca upływ czasu w rozgrywce
	{
		timePointMoves = GameObject.Find ("scores").GetComponent<Text> (); //wyszukiwanie pola tekstowego "time", obsługującego wyświetlanie upływu czasu
		//string sTimer = timer.ToString ("0.00");
		if (timeMode == "True") 
		{
			timePointMoves.text = "Czas rozgrywki: " + timer.ToString ("0.00")+" s"+ ", wykonano ruchów: " + movesCounter.ToString ();	
		}
		if (timeMode == "False") 
		{
			timePointMoves.text = "Pozostało czasu: " + timer.ToString ("0.00")+" s"+", zdobyto punktów: " + pointsCounter.ToString ();	
		}
			


	}

	private void modeText()///procedura wyświetlająca upływ czasu w rozgrywce
	{		
		mode = GameObject.Find ("modeText").GetComponent<Text> (); //wyszukiwanie pola tekstowego "time", obsługującego wyświetlanie upływu czasu
		//string sTimer = timer.ToString ("0.00");
		if (PlayerPrefs.HasKey ("Nick")) {
			mode.text = "Gracz " + nick + ", tryb \"" + currentMode + "\"" + ", wielkość tablicy " + tabSizeName;	
		} 
		else 
		{
			mode.text = " Tryb \"" + currentMode + "\"" + " ,wielkość tablicy " + tabSizeName;
		}

	}

	private void currentStates()///wykrywanie rodzaju trybu gry oraz wielkości tablicy gry po zakończonej rozgrywce
	{
		if(timeMode=="True")
		{
			currentMode = "na czas";
		}
		if(timeMode=="False")
		{
			currentMode="na punkty";
		}

		if (tabSize == 16) 
		{
			currentTabSize = 44;
			tabSizeName = "4x4";
		}
		if (tabSize == 20) 
		{
			currentTabSize = 45;
			tabSizeName = "4x5";
		}
		if (tabSize == 24) 
		{
			currentTabSize = 46;
			tabSizeName = "4x6";
		}
	}
	private void playerNick()///sprawdzenie czy gracz jest zalogowany i pobranie jego nicka
	{		
		
		if (PlayerPrefs.HasKey ("Nick")) 
		{
			nick = PlayerPrefs.GetString ("Nick");
		} 
		else 
		{
			nick = "null";
		}
	}

	private void saveTextStatus()///obsłguga tekstu na scenie związanego z logowaniem gracza
	{	
		Button saveButton;
		Button backButton;
		saveButton = GameObject.Find ("btn4x4").GetComponent<Button> ();
		backButton = GameObject.Find ("btn4x5").GetComponent<Button> ();	
		saveTextMsg = GameObject.Find ("saveText").GetComponent<Text> ();
		if (PlayerPrefs.HasKey ("Nick")) 
		{
			saveTextMsg.text = "Czy chcesz zapisać swój wynik w systemie rankingowym?";
			saveButton.GetComponentInChildren<Text>().text = "Zapisz!";
			backButton.GetComponentInChildren<Text>().text = "Nie zapisuj, wróć do głównego menu";
		} 
		else 
		{
			saveTextMsg.text = "Aby zapisać wynik w systemie rankingowym musisz być zalogowany.";
			saveButton.enabled=false;
			saveButton.GetComponentInChildren<Text>().text = "";
			saveButton.GetComponent<Image>().color = new Color32(216,152,121,0);
			backButton.GetComponentInChildren<Text>().text = "Wróć do głównego menu";
		}
	}
}
