using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoginController ///Klasa obsługująca logowanie w grze 
{
	
	HSController comm = new HSController();
	string nick; /// pole zawierające nick
	string pass; /// pole zawierające hasło
	public Text status; /// pobsługa tekstu statusu na scenie
	public string LoginUrl = "http://ememoscript.gear.host/login.php";
	public string SecureKey = "eMemoSecretKey";

	// Use this for initialization
	void Start () ///procedura obowiązkowa, wywoływana raz podczas startu aplikacji przez silnik
	{		
		

	}



	// Update is called once per frame
	void Update () ///procedura obowiązkowa, wywoływana cyklicznie co ramkę przez silnik
	{

	}


	public IEnumerator Query_Account (string nick, string pass) /// główna procedura logująca, łączenie z bazą danych i sprawdzanie czy istnieje podane konto
	{
		status = GameObject.Find ("Status").GetComponent<Text> ();
		Debug.Log ("Nick z logging: "+nick);
		Debug.Log ("Pass z logging: "+pass);
		string hash = comm.Md5Sum(nick + pass + SecureKey);
		string acc = LoginUrl + "?" + "nick=" + WWW.EscapeURL(nick) + "&pass=" + WWW.EscapeURL(pass)+ "&hash=" + hash;
		WWW query = new WWW (acc);
		Debug.Log ("Wyslane na serwer: " + acc);
		//WarningMsg.text = "Please Wait ... ";
		yield return query;
		Debug.Log ("Zwrotka z serwera: " + query.text);
		string[] split = query.text.Split (',');
		if (split [0].Trim () == "1")
		{
			PlayerPrefs.SetString ("Nick", nick);

			status.text = "Zalogowano!";
			Debug.Log("Zalogowano");
			SceneManager.LoadScene("mainMenu");

			}  else 
			{				
				status.text = query.text;

			}	

	}
}

