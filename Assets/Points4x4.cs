using UnityEngine;
using System.Collections;

public class Points4x4 : MonoBehaviour ///Skrypt obsługujący grę w trybie "na punkty" dla tablicy o wielkości 4x4 
{
	
	GameController points4x4 = new GameController(16, false, 20f);
	void Start () ///procedura obowiązkowa, wywoływana raz podczas startu aplikacji przez silnik
	{		
		points4x4.Start ();
	}
	
	// Update is called once per frame
	void Update () ///procedura obowiązkowa, wywoływana cyklicznie co ramkę przez silnik
	{
		points4x4.Update ();
	}
}