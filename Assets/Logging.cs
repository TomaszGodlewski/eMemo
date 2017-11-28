using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Logging : MonoBehaviour ///Skrypt obsługujący logowanie
{
	
	LoginController log = new LoginController();
	[SerializeField] private InputField userName;
	[SerializeField] private InputField passwordName;

	string messStat;
	Text msgStatus;
	// Use this for initialization
	void Start () ///procedura obowiązkowa, wywoływana raz podczas startu aplikacji przez silnik
	{		
//		loginStatus ();
		messageStatus ();

	}


	// Update is called once per frame
	void Update () ///procedura obowiązkowa, wywoływana cyklicznie co ramkę przez silnik
	{
		
	}

	public void Login () ///obsługa przycisku na scenie, zaloguj
	{
		if (!PlayerPrefs.HasKey ("Nick")) 
		{
			StartCoroutine (log.Query_Account (userName.text, passwordName.text));

		} 
		else 
		{
			PlayerPrefs.DeleteAll ();
		}
	}

	public void onClickPowrot() ///obsługa przycisku na scenie, wróc do menu głównego
	{
		
		SceneManager.LoadScene("mainMenu");
	}

	public void messageStatus() ///obsługa tekstu statusu logowania 
	{
		msgStatus = GameObject.Find ("Status").GetComponent <Text>();
		if (PlayerPrefs.HasKey ("Nick")) 
		{
			messStat = "Użytkownik zalogowany jako "+PlayerPrefs.GetString ("Nick");
		} 
		else 
		{
			messStat = "Zaloguj się podając swój nick i hasło";
		}
		msgStatus.GetComponentInChildren<Text>().text = messStat;

	}

}

