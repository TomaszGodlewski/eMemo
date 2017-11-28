using UnityEngine;
using System.Collections;

public class Time4x6 : MonoBehaviour ///Skrypt obsługujący grę w trybie "na czas" dla tablicy o wielkości 4x6 
{
	
	GameController time4x6 = new GameController(24,true,0f);
	void Start () ///procedura obowiązkowa, wywoływana raz podczas startu aplikacji przez silnik
	{		
		time4x6.Start ();
	}
	
	// Update is called once per frame
	void Update () ///procedura obowiązkowa, wywoływana cyklicznie co ramkę przez silnik
	{
		time4x6.Update ();
	}
}