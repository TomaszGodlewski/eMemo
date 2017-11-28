using UnityEngine;
using System.Collections;

public class Points4x6 : MonoBehaviour ///Skrypt obsługujący grę w trybie "na punkty" dla tablicy o wielkości 4x6 
{
	
	GameController points4x6 = new GameController(24, false, 40f);
	void Start () ///procedura obowiązkowa, wywoływana raz podczas startu aplikacji przez silnik
	{		
		points4x6.Start ();
	}
	
	// Update is called once per frame
	void Update () ///procedura obowiązkowa, wywoływana cyklicznie co ramkę przez silnik
	{
		points4x6.Update ();
	}
}