using UnityEngine;
using System.Collections;

public class QuickGame : MonoBehaviour ///Skrypt obsługujący grę w trybie "szybka gra" dla tablicy o wielkości 4x4 
{
	
	GameController quickGame = new GameController();
	void Start () ///procedura obowiązkowa, wywoływana raz podczas startu aplikacji przez silnik
	{		
		quickGame.Start ();
	}
	
	// Update is called once per frame
	void Update () ///procedura obowiązkowa, wywoływana cyklicznie co ramkę przez silnik
	{
		quickGame.Update ();
	}
}