using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour ///Skrypt obsługujący scenę podsumowania zapisu rozgrywki do bazy danych
{ 
	
	string succes; /// pole wykorzystywane podczas pobierania stanu zapisu

	private Text saveText; /// obsługa tekstu na scenie


	// Use this for initialization
	void Start () ///procedura obowiązkowa, wywoływana raz podczas startu aplikacji przez silnik
	{
		succes = PlayerPrefs.GetString ("Save");
		saveStatusText ();
	
	}
	
	// Update is called once per frame
	void Update () ///procedura obowiązkowa, wywoływana cyklicznie co ramkę przez silnik
	{
		if(Input.GetKey("escape")){
			Application.Quit ();
		}
	}



	public void onClicReturnMM()///obsługa przycisku na scenie, powrót do menu głównego
	{
		PlayerPrefs.DeleteKey ("Save");
		PlayerPrefs.DeleteKey ("Moves");
		PlayerPrefs.DeleteKey ("Points");
		PlayerPrefs.DeleteKey ("TabSize");
		PlayerPrefs.DeleteKey ("Mode");
		PlayerPrefs.DeleteKey ("Time");
		SceneManager.LoadScene("mainMenu");
	}



	void saveStatusText()///procedura wyświetlająca wynik zapisu rozgrywki do bazy danych
	{		
		saveText = GameObject.Find ("endGameText").GetComponent<Text> (); //wyszukiwanie pola tekstowego "countText", obsługującego wyświetlanie licznika ruchów
		if (succes == "True") 
		{
			saveText.text = "Wyniki zostały zapisane!";
		}
		if (succes == "False") 
		{
			saveText.text = "Wyniki nie zostały zapisane! Sprawdź połączenie z internetem.";
		}

	}


}
