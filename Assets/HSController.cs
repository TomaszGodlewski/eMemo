using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HSController ///Klasa obsługująca funkcje sieciowe (bez logowania) w grze 
{
	
	private string secretKey = "eMemoSecretKey"; /// 
	public string addScoreURL = "http://ememoscript.gear.host/addscore2.php?"; //

	void Start()///procedura obowiązkowa, wywoływana raz podczas startu aplikacji przez silnik
	{
		
	}

	public string Md5Sum(string strToEncrypt) /// Funkcja haszująca wykorzystywana w komunikacji aplikacja - baza danych
	{
		System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
		byte[] bytes = ue.GetBytes(strToEncrypt);

		// 
		System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
		byte[] hashBytes = md5.ComputeHash(bytes);

		// 
		string hashString = "";

		for (int i = 0; i < hashBytes.Length; i++)
		{
			hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
		}

		return hashString.PadLeft(32, '0');
	}


	// 
	public IEnumerator PostScores(float time, int moves, int points, string nick, int table, string mode) ///procedura wysyłająca wyniki do bazy danych
	{
		
		string hash = Md5Sum(nick + moves + secretKey);

		string post_url = addScoreURL + "time=" + Round(time,2) + "&moves=" + moves + "&points=" + points +"&nick=" + WWW.EscapeURL(nick)+ "&table="+ table+ "&mode="+ WWW.EscapeURL(mode)+"&hash=" + hash;

		WWW hs_post = new WWW(post_url);
		yield return hs_post; 

		if (hs_post.error != null) {
			Debug.Log ("Pojawił się błąd podczas zapisywania wyniku rozgrywki: " + hs_post.error);
			saveMode ("False");
			SceneManager.LoadScene("Save");
		} else 
		{
			Debug.Log ("Wyslane na serwer: " + post_url);
			Debug.Log ("Odpowiedz serwera: "+ hs_post.text);
			saveMode ("True");
			SceneManager.LoadScene("Save");
		}
	}

	public float Round(float value, int digits)/// funkcja zaokrąglająca wynik czasu rozgrywki do 2 miejsc po przecinku
	{
		float mult = Mathf.Pow(10.0f, (float)digits);
		return Mathf.Round(value * mult) / mult;
	}

	private void saveMode(string _save) //Procedura zapisująca wynik zapisania stanu rozgrywki do bazy danych
	{
		Debug.Log ("save: " + _save);
		PlayerPrefs.SetString ("Save", _save);
	}
}