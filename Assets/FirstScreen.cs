using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;

public class FirstScreen : MonoBehaviour ///Skrypt obsługujący menu główne
{



	void Start () ///procedura obowiązkowa, wywoływana raz podczas startu aplikacji przez silnik
	{		
		
	}
	
	// Update is called once per frame
	void Update () ///procedura obowiązkowa, wywoływana cyklicznie co ramkę przez silnik
	{
		
		
//		if(Input.GetKey("escape")){
//			Application.Quit ();
//		}
	}



	public void onClickPlay() ///obsługa przycisku na scenie, wejscie do głownego menu
	{
		SceneManager.LoadScene("mainMenu");

	}



	public void onClicZakoncz()///obsługa przycisku na scenie,wyjście z gry
	{
		PlayerPrefs.DeleteAll ();
		Application.Quit ();
	}


}
