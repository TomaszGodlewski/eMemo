using UnityEngine;
using System.Collections;

public class Points4x5 : MonoBehaviour ///Skrypt obsługujący grę w trybie "na punkty" dla tablicy o wielkości 4x5 
{
	
	GameController points4x5 = new GameController(20, false, 30f);
	void Start () ///procedura obowiązkowa, wywoływana raz podczas startu aplikacji przez silnik
	{		
		points4x5.Start ();
	}
	
	// Update is called once per frame
	void Update () ///procedura obowiązkowa, wywoływana cyklicznie co ramkę przez silnik
	{
		points4x5.Update ();
	}
}