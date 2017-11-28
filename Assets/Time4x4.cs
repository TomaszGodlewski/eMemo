using UnityEngine;
using System.Collections;

public class Time4x4 : MonoBehaviour ///Skrypt obsługujący grę w trybie "na czas" dla tablicy o wielkości 4x4 
{
	
	GameController time4x4 = new GameController(16,true,0f);
	void Start () ///procedura obowiązkowa, wywoływana raz podczas startu aplikacji przez silnik
	{		
		time4x4.Start ();
	}
	
	// Update is called once per frame
	void Update () ///procedura obowiązkowa, wywoływana cyklicznie co ramkę przez silnik
	{
		time4x4.Update ();
	}
}