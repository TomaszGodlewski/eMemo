using UnityEngine;
using System.Collections;

public class Time4x5 : MonoBehaviour ///Skrypt obsługujący grę w trybie "na czas" dla tablicy o wielkości 4x5 
{
	
	GameController time4x5 = new GameController(20,true,0f);
	void Start () ///procedura obowiązkowa, wywoływana raz podczas startu aplikacji przez silnik
	{		
		time4x5.Start ();
	}
	
	// Update is called once per frame
	void Update () ///procedura obowiązkowa, wywoływana cyklicznie co ramkę przez silnik
	{
		time4x5.Update ();
	}
}