using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Collections;

public class GameController ///Główna klasa gry, obsługująca logikę rozgrywki, przyciski kart 
{
	
	private MonoBehaviour mb; ///klasa bazowa potrzebna przy wywoływaniu corutines
	private static int tabSize; ///wielkość tablicy
	private static bool timeMode; ///tryb gry "na czas"
	private static bool quickGameMode;///tryb gry "szybka gra"
	//private static float timeLimit;
	private float timer; ///zmienna zawierająca czas rozgrywki
	private int movesCounter; ///licznik ruchów
	private int pointsCounter; ///licznik odkrytych par wykorzystywany przy nadawaniu zmiennej "bool time" wartości false po odkryciu (ilczba pól gry)/2 

	public GameController ()///Konstruktor obsługujący tryb "szybka gra"
	{
		tabSize = 16;
		timeMode = true;
		timer = 0f;
		quickGameMode = true;
	}

	public GameController (int _tabSize)///Konstruktor obsługujący tryb "na czas"
	{
		tabSize = _tabSize;
		timeMode = true;
		timer = 0f;
		quickGameMode = false;
	}

	public GameController (int _tabSize, bool _timeMode, float _timeLimit)///Konstruktor obsługujący tryb "na punkty"
	{
		tabSize = _tabSize;
		timeMode = _timeMode;
		timer = _timeLimit;
		quickGameMode = false;
	}


	  
	private bool time=false; ///zmienna obsługująca odświeżanie upływu czasu w rozgrywce
	private Text countText; ///obsługa wyświetlania licznika ruchów
	private Text countTime; ///obsługa wyświetlania upływu czasu


	///obsługa przycisków pól gry
	public Button button; ///obsługa przycisków pól gry
	public Button button0;///obsługa przycisków pól gry
	public Button button1;///obsługa przycisków pól gry
	public Button button2;///obsługa przycisków pól gry
	public Button button3;///obsługa przycisków pól gry
	public Button button4;///obsługa przycisków pól gry
	public Button button5;///obsługa przycisków pól gry
	public Button button6;///obsługa przycisków pól gry
	public Button button7;///obsługa przycisków pól gry
	public Button button8;///obsługa przycisków pól gry
	public Button button9;///obsługa przycisków pól gry
	public Button button10;///obsługa przycisków pól gry
	public Button button11;///obsługa przycisków pól gry
	public Button button12;///obsługa przycisków pól gry
	public Button button13;///obsługa przycisków pól gry
	public Button button14;///obsługa przycisków pól gry
	public Button button15;///obsługa przycisków pól gry
	public Button button16;///obsługa przycisków pól gry
	public Button button17;///obsługa przycisków pól gry
	public Button button18;///obsługa przycisków pól gry
	public Button button19;///obsługa przycisków pól gry
	public Button button20;///obsługa przycisków pól gry
	public Button button21;///obsługa przycisków pól gry
	public Button button22;///obsługa przycisków pól gry
	public Button button23;///obsługa przycisków pól gry
	public Button quit;///obsługa przycisku wyjścia
	public Button play;///obsługa przycisku resetu rizgrywki

	public  Button[] bButtons=new Button[tabSize]; ///definicja tablicy gry, tablica przycisków
	public  string[] sButtonFaces = new string[tabSize]; ///ostateczna tablica nazw awersów w rozdaniu. Tworzona jest poprzez losowy wybór awersów z listy sFaces i przypisywania ich kolejno do elementów tablicy. 

	public ArrayList sFaces = new ArrayList(); ///początkowa lista nazw assetów do wszystkich awersów kart, wykorzystywana do losowania rozkładu kart w rozdaniu. 
	//listy porównawcze
	public ArrayList compareFaces = new ArrayList(); ///dwuelementowa lista, wykorzystywana do przechowywania nazw awersów przy porównaniu wybranych kart.
	public ArrayList compareIdx = new ArrayList(); ///dwuelementowa lista, wykorzystywana do przechowywania indeksów kart uczestniczącyh przy porównaniu awersów.



	public void Start ()///procedura obowiązkowa, wywoływana raz podczas startu aplikacji przez silnik
	{			
		//SetCountTime ();
		Debug.Log("Wartosc timeMod: "+ timeMode);
		quitPlayAgainListeners ();///łączenie nazw przycisków wykorzystywanych w UI z przyciskami zdefiniowanymi w skrypcie, dodawania listenerów wykorzystywanych w obsłudze gry
		createButtonsArrays ();///Tworzenie tablic przycisków
		//addButtonsListeners ();///łączenie nazw przycisków wykorzystywanych w UI z przyciskami zdefiniowanymi w skrypcie, dodawania listenerów wykorzystywanych w grze przycisków
		bButtons = addButtonsListeners(bButtons);
		startGame ();
	}
	public void Update ()///procedura obowiązkowa, wywoływana cyklicznie co ramkę przez silnik
	{
		timerText (); ///procedura wyświetlająca upływ czasu
		if (time) 
		{ 
			timeFlow ();
			timerText ();
		}
		
		if (timeMode) 
		{
			movesCounterText (); ///procedura wyświetlająca liczbę ruchów

		} else 
		{
			pointsCounterText ();///procedura wyświetlająca liczbę punktów
			if (timer <= 0f) 
			{				
				bButtons = lockCards(bButtons);
				time = false;
				Debug.Log ("Koniec czasu!");
				//if (!quickGameMode && isLogged ()) 
				//{
					saveMoves (movesCounter);
					savePoints (pointsCounter);
					saveTime (timer);
					saveMode (timeMode);
					saveTabSize (tabSize);
					SceneManager.LoadScene ("summary");
				//}
			}
		}
	}

	private void startGame()
	{		
		mb = GameObject.FindObjectOfType<MonoBehaviour>();
		mb.StartCoroutine(begin());
	}
	private IEnumerator begin() 
	{		
		fillingCards (); ///przygotowanie nazw awersów kart, 
		setTable();/// losowanie rozdania oraz tworzenie ostatecznej tablicy rozdania sButtonFaces
		Debug.Log(Time.time); ///wiadomość diagnostyczna wyświetlająca czas w konsoli środowiska
		bButtons = lockCards(bButtons);
		yield return new WaitForSeconds(0f); ///opóźnienie zakrycia awersów pól gry rewersami po wylosowaniu tablicy gry
		bButtons = unLockCards(bButtons);
		//unLockCards();
		time = true; //
		Debug.Log(Time.time);///wiadomość diagnostyczna wyświetlająca czas w konsoli środowiska
		fillingCovers();///wypełnianie w początkowej facie gry wszyskich kart ich rewersem

	}

	private bool fillingCards ()///Przygotowywania nazw awersów kart, losowanie rozdania oraz tworzenie ostatecznej tablicy rozdania sButtonFaces
	{
		//wypełnianie listy nazw awersów
		sFaces.Add ("brazowy");
		sFaces.Add ("brazowy");
		sFaces.Add ("czarny");
		sFaces.Add ("czarny");
		sFaces.Add ("czerwony");
		sFaces.Add ("czerwony");
		sFaces.Add ("niebieski");
		sFaces.Add ("niebieski");
		sFaces.Add ("zolty");
		sFaces.Add ("zolty");
		sFaces.Add ("zielony");
		sFaces.Add ("zielony");
		sFaces.Add ("fioletowy");
		sFaces.Add ("fioletowy");
		sFaces.Add ("bialy");
		sFaces.Add ("bialy");
		if (tabSize >= 20) 
		{
			sFaces.Add ("apple");
			sFaces.Add ("apple");
			sFaces.Add ("blackberry");
			sFaces.Add ("blackberry");
		}
		if (tabSize == 24) 
		{
			sFaces.Add ("pear");
			sFaces.Add ("pear");
			sFaces.Add ("rasberry");
			sFaces.Add ("rasberry");
		}
		return true;
	}

	private void setTable()///procedura zapełniająca tablicę gry
	{
		int i = 0;
		while (sFaces.Count>0) 
		{			
			int j = randomGenerator(0,sFaces.Count); ///losowanie liczby w zakresie aktualnej wielkości listy nazw awersów
			sButtonFaces [i] = (string)sFaces [j]; ///losowe przypisywanie nazw awersów do ostatecznej tablicy nazw awersów
			Sprite sprite = Resources.Load <Sprite> ((string)sFaces[j]); ///przygotowywanie do przypisania assetu o wylosowanej nazwie 
			bButtons [i].image.overrideSprite = sprite; ///przypisanie assetu do tablicy gry
			sFaces.RemoveAt(j); ///usunięcie wylosowanej nazwy awersu z listy nazw awersów
			i++;
		}
	}



	private Button[] addButtonsListeners(Button[] bButtons)///powiązanie nazw przycisków wykorzystywanych w UI z przyciskami zdefiniowanymi w skrypcie, dodawania listenerów wykorzystywanych w grze przycisków
	{
		int iTab = bButtons.Length;
		for (int i = 0; i < iTab; i++) 
		{				
			bButtons [i] = GameObject.Find ("button"+i).GetComponent<Button> ();
			int iButtonIdx = i;
			bButtons[i].onClick.AddListener (() => {GameLogic(iButtonIdx);});
		}
		return bButtons;
	}

	private void GameLogic(int i)///funkcja wywoływana poprzez wybór zakrytej karty
	{	
		movesCounter++;
		Sprite sprite = Resources.Load <Sprite> (sButtonFaces[i]); ///przygotowanie awersu wybranego pola gry
		compareFaces.Add (sButtonFaces[i]); ///zapisanie nazwy odsłoniętego awersu do listy porównującej nazwy awersów
		compareIdx.Add (i); ///zapisywanie indeksu z ostatecznej tablicy nazw awersów 
		bButtons[i].image.overrideSprite = sprite; ///przypisanie awersu do przycisku
		bButtons [i].enabled=false; ///zablokowanie możliwości ponownego naciśnięcia pola gry
		Compare ();
	}

	private void Compare()///Wywołanie obsługi porównania wybranych kart
	{	
		mb = GameObject.FindObjectOfType<MonoBehaviour>();
		//someMonoInstance.StartCoroutine("DoCoroutine", this.beginCompare());
		mb.StartCoroutine (beginCompare ());
	}
	private IEnumerator beginCompare()///Procedura porównująca dwie wybrane karty
	{
		if (compareFaces.Count==2) 
		{
			bButtons = lockCards(bButtons);
			Debug.Log ("Sprawdzam!");
			//counter++;

			if(compString((string)compareFaces [0],(string)compareFaces [1]))
			{
				Debug.Log ("Nie pasuje!"); ///wiadomość diagnostyczna wyświetlająca się w konsoli środowiska
				Sprite cover = Resources.Load <Sprite> ("cover"); ///przygotowanie rewersu pola gry
				yield return new WaitForSeconds(0.3f); ///opóźnienie zakrycia odkrytych awersów rewersami
				bButtons [(int)(compareIdx [0])].image.overrideSprite = cover; ///zakrycie rewersem pierwszego odkrytego pola gry
				bButtons [(int)(compareIdx [1])].image.overrideSprite = cover; ///zakrycie rewersem drugiego odkrytego pola gry
				//czyszczenie list porównawczych
				compareFaces.Clear (); 
				compareIdx.Clear ();

			} else 
			{
				Debug.Log ("Pasuje!"); ///wiadomość diagnostyczna wyświetlająca się w konsoli środowiska
				pointsCounter++; ///zwiększanie zmiennej przechowującej liczbę odkrytych par
				bButtons [(int)(compareIdx [0])] = null; ///zablokowanie możliwości ponownego naciśnięcia pola gry
				bButtons [(int)(compareIdx [1])] = null;
				//czyszczenie list porównawczych
				compareFaces.Clear ();
				compareIdx.Clear ();

				if (pointsCounter == tabSize/2) 
				{
//					Debug.Log ("Timer: " + timer);
//					Debug.Log ("movesCounter: " + movesCounter);
					if ((quickGameMode)/*||(!quickGameMode&&!isLogged())*/) 
					{
						Debug.Log ("Szybka gra!");
					}
					else
					{
						saveMoves (movesCounter);
						savePoints (pointsCounter);
						saveTime (timer);
						saveMode (timeMode);
						saveTabSize (tabSize);
						SceneManager.LoadScene ("summary");
					//StartCoroutine(controler.PostScores(timer, counter, 0, "Aga", 46, "na czas"));
					//myMB.print ("Koniec!"); //wiadomość diagnostyczna wyświetlająca się w konsoli środowiska
					}
					time = false;
				}

			}
			bButtons = unLockCards(bButtons);
		}
	}

	public bool compString(string str1, string str2)///Procedura wykorzystywana przy porównanie nazw kart
	{
		return str1 != str2;
	}

	public bool createButtonsArrays()///Tworzenie tablicy przycisków
	{		
		bButtons [0] = button0;
		bButtons [1] = button1;
		bButtons [2] = button2;
		bButtons [3] = button3;
		bButtons [4] = button4;
		bButtons [5] = button5;
		bButtons [6] = button6;
		bButtons [7] = button7;
		bButtons [8] = button8;
		bButtons [9] = button9;
		bButtons [10] = button10;
		bButtons [11] = button11;
		bButtons [12] = button12;
		bButtons [13] = button13;
		bButtons [14] = button14;
		bButtons [15] = button15;
		if (tabSize >= 20) 
		{
			bButtons [16] = button16;
			bButtons [17] = button17;
			bButtons [18] = button18;
			bButtons [19] = button19;
		}
		if (tabSize == 24) 
		{
			bButtons [20] = button20;
			bButtons [21] = button21;
			bButtons [22] = button22;
			bButtons [23] = button23;
		}
		return true;
	}

	private void fillingCovers()///Wypełnianie w początkowej facie gry wszyskich pól gry ich rewersem
	{		
		for(int i=0;i<tabSize;i++)
		{ 
		Sprite cover = Resources.Load <Sprite> ("cover"); ///przygotowanie rewersu pola gry
		bButtons[i] = GameObject.Find ("button"+i).GetComponent<Button>(); ///wyszukiwanie przycisków stworzonych w Canvasie Unity
		bButtons[i].image.overrideSprite = cover; ///zakrycie rewersem pola gry
		}

	}

	private void quitPlayAgainListeners()///łączenie nazw przycisków wykorzystywanych w UI z przyciskami zdefiniowanymi w skrypcie, dodawania listenerów wykorzystywanych w obsłudze gry
	{
		Sprite sprite = Resources.Load <Sprite> ("szary"); //przygotowanie tła przycisków "Zakończ" oraz "Jeszcze raz"
		quit = GameObject.Find ("quit").GetComponent<Button> (); //wyszukiwanie przycisku "Zakończ grę"
		quit.image.overrideSprite = sprite; //ustawienie tła przycisku
		quit.onClick.AddListener (()=> {quitTable();}); //dodanie listenera do przycisku "Zakończ grę"
		play = GameObject.Find ("play").GetComponent<Button> (); //wyszukiwanie przycisku "Jeszcze raz"
		play.onClick.AddListener (()=> {playAgain();}); //dodanie listenera do przycisku "Jeszcze raz"
		play.image.overrideSprite = sprite; //ustawienie tła przycisku
	}

	private void quitTable()///procedura wyjścia z gry (nie działa w środowisku uruchomieniowym Unity)
	{
		Debug.Log ("Bye!"); ///wiadomość diagnostyczna wyświetlająca się w konsoli środowiska
		//Application.Quit ();
		SceneManager.LoadScene("mainMenu");
	}

	private void playAgain()///procedura resetująca rozdanie
	{
		//SceneManager.LoadScene(this);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	private void movesCounterText()///procedura wyświetlająca liczbę ruchów
	{		
		countText = GameObject.Find ("countText").GetComponent<Text> (); ///wyszukiwanie pola tekstowego "countText", obsługującego wyświetlanie licznika ruchów
		countText.text = "Ruchy:" + movesCounter.ToString ();	

	}

	private void pointsCounterText()///procedura wyświetlająca liczbę punktów
	{		
		countText = GameObject.Find ("countText").GetComponent<Text> (); ///wyszukiwanie pola tekstowego "countText", obsługującego wyświetlanie licznika ruchów
		countText.text = "Punkty" + pointsCounter.ToString ()+"/"+(tabSize/2).ToString();	

	}

	private void timerText()///procedura wyświetlająca upływ czasu w rozgrywce
	{
		countTime = GameObject.Find ("time").GetComponent<Text> (); ///wyszukiwanie pola tekstowego "time", obsługującego wyświetlanie upływu czasu
		if(timer <= 0f)
		{
			timer = 0.00f;
		}
		string sTimer = timer.ToString ("0.00");
		countTime.text = "Czas " + sTimer;	


	}

	private void timeFlow()///procedura obsługująca upływ czasu w rozgrywce
	{
		if (timeMode)
		{
			timer += Time.deltaTime;
		} else 
		{
			timer -= Time.deltaTime;
		}
	}



	private Button[] lockCards(Button[] bButtons) ///funkcja blokująca możliwość naciśnięcia przycisku
	{
		int iTab = bButtons.Length;
		for (int i = 0; i < iTab; i++) 
		{
			if ( bButtons[i] != null) 
			{
				bButtons [i].enabled = false;
			}
		}
		return  bButtons;
	}

	private Button[] unLockCards(Button[] bButtons) ///funkcja odblokowująca możliwość naciśnięcia przycisku
	{
		int iTab = bButtons.Length;
		for (int i = 0; i < iTab; i++) 
		{
			if ( bButtons[i] != null) 
			{
				bButtons [i].enabled = true;
			}
		}
		return  bButtons;
	}

	public int randomGenerator(int min, int max) /// generator liczb losowych wykorzystywany przy tworzeniu tablicy gry
	{	
		return UnityEngine.Random.Range (min, max);
	}

	private void saveMoves(int _movesCounter) /// zapisywanie liczby ruchów
	{		
		Debug.Log ("movesCounter: " + _movesCounter);
		PlayerPrefs.SetInt ("Moves", _movesCounter);
	}

	private void savePoints(int _pointsCounter) /// zapisywanie liczby punktów
	{		
		Debug.Log ("pointsCounter: " + _pointsCounter);
		PlayerPrefs.SetInt ("Points", _pointsCounter);
	}

	private void saveTabSize(int _tabSize) /// zapisywanie wielkości tablicy
	{		
		Debug.Log ("_tabSize: " + _tabSize);
		PlayerPrefs.SetInt ("TabSize", _tabSize);
	}

	private void saveMode(bool _timeMode) /// zapisywanie trybu gry (wartość boolowska) jako string
	{
		Debug.Log ("_tabSize: " + _timeMode);
		PlayerPrefs.SetString ("Mode", _timeMode.ToString());
	}

	private void saveTime(float _timer) /// zapisywanie czasu rozgrywki
	{
		Debug.Log ("Timer: " + _timer);
		PlayerPrefs.SetFloat ("Time", _timer);
	}

	public int getTabSize() ///geter zwracający wielkość tablicy gry
	{		
		return tabSize;
	}

	public bool getTimeMode() ///geter zwracający true gdy aktualny tryb jest trybem "na czas"
	{		
		return timeMode;
	}

	public float getTimeLimit() ///geter zwracający czas rozgrywki
	{		
		return timer;
	}

	bool isLogged() ///sprawdzanie czy istnieje zalogowany gracz
	{
		if (PlayerPrefs.HasKey ("Nick"))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

}


