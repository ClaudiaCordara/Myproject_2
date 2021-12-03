using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeckManager : MonoBehaviour
{

	public static DeckManager instance;
    public Card[] deck;
	public Card[] fulldeck;
	private string[] Names_hard= new string[53]{"caffe", "cane", "cappello", "caraffa", "case", "castagna", "cavalli", "cavi", "chela", "chiave", "chiavi", "chiodi", "chitarra", "coccinella", "coccodrillo",  "coda",  "collo",  "colombo",  "corda",  "corvo",  "cozza",  "cuccia", "cuore", "cuscino", "gallina", "gambe", "gambero", "gambo", "ganci", "gatto", "ghepardo", "gheriglio", "ghiacciolo", "ghiande", "ghiro", "gobba", "gomitolo", "gomme", "gorilla", "gregge", "guanto", "gufo", "guinzaglio", "scacchi", "scacchiera", "scarpe", "scatola", "scheletro", "schiuma", "scoiattolo", "scopa", "scorpione", "scudo"};
	private string[] Names_soft= new string[21]{"cellula", "cerotto", "cervello", "ciabatta","cicogna", "cielo", "cigno", "cinghiale", "cintura",  "cipolla", "gelato", "gemelli", "gengiva", "genio", "gigante", "ginocchio", "giraffa", "gnomi", "sceriffo", "sciarpa", "scimmia"};

	private string[] LevelTypeWithDifficultyLow = new string[10]{"A","S","S","S","S","S","S","S","S","S"}; // 10% audio
	private string[] LevelTypeWithDifficultyMed = new string[10]{"A","A","A","S","S","S","S","S","S","S"}; // 30% audio
	private string[] LevelTypeWithDifficultyHig = new string[10]{"A","A","A","A","A","S","S","S","S","S"}; // 50% audio
	public int cardPerDeck = 10;
	public int deckLength = 74;

	public bool allowWordsC;
	public bool allowWordsG;
	public bool allowWordsSC;
	public int levelDifficulty;

	void Awake () {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        }

        instance = this; 
        DontDestroyOnLoad(this.gameObject);

		allowWordsC = (PlayerPrefs.GetInt("GameAllowWordsC", 0)==1);
		allowWordsG = (PlayerPrefs.GetInt("GameAllowWordsG", 0)==1);
		allowWordsSC = (PlayerPrefs.GetInt("GameAllowWordsSC", 0)==1);
		levelDifficulty = PlayerPrefs.GetInt("GameDifficulty", 0);
		if (levelDifficulty < 1) {
			// inizializzazione iniziale a 1 == facile
			levelDifficulty = 1;
        }

	}
	
    // Start is called before the first frame update
    void Start() {
	    deck = new Card[cardPerDeck];
        fulldeck = new Card[deckLength+1];
		int index=0;
		for (int i=0; i<21; i++){
			Card temp = new Card();
			temp.idx = index;
			temp.name = Names_soft[i];
			temp.soft = true;
			temp.IsC = Names_soft[i].StartsWith("c");
			temp.IsG = Names_soft[i].StartsWith("g");
			temp.IsSC = Names_soft[i].StartsWith("sc");
			temp.artwork = Resources.Load<Sprite>(temp.name);
			temp.clip = Resources.Load<AudioClip>("Audio/" + temp.name);
			temp.IsAudio = false;
            fulldeck[index] = temp;
            index++;
            //Debug.Log(Names_soft[i].StartsWith("c");
		}	
		for (int i=0; i<53; i++){
			Card temp = new Card();
			temp.idx = index;
			temp.name = Names_hard[i];
			temp.soft = false;
			temp.IsC = Names_hard[i].StartsWith("c");
			temp.IsG = Names_hard[i].StartsWith("g");
			temp.IsSC = Names_hard[i].StartsWith("sc");
			temp.artwork = Resources.Load<Sprite>(temp.name);
			temp.clip = Resources.Load<AudioClip>("Audio/" + temp.name);
			temp.IsAudio = false;
			fulldeck[index] = temp;
			index++;
			//Debug.Log(Names_hard[i]+" - "+i.ToString()+" + "+index.ToString());
		}

		Shuffle();
    }

    

    public void Shuffle()
    {
	    int replacements = UnityEngine.Random.Range(100, 300);
	    for (int i=0; i < replacements; i++){
		    int A = UnityEngine.Random.Range(0, deckLength - 1);
		    int B = UnityEngine.Random.Range(0, deckLength - 1);

		    Card a = fulldeck[A];
		    Card b = fulldeck[B];
		    Card c = fulldeck[A];

		    a = b;
		    b = c;

		    fulldeck[A] = a;
		    fulldeck[B] = b;
	    }

		for (int i = 0; i < deckLength; i++) {
			fulldeck[i].IsAudio = false;
		}

		// shaping deck
		int n = 0;
		for (int i = 0; i < deckLength; i++) {
			if (allowWordsC & fulldeck[i].IsC) {
				deck[n] = fulldeck[i];
				n++;
			} else if (allowWordsG & fulldeck[i].IsG) {
				deck[n] = fulldeck[i];
				n++;
			} else if (allowWordsSC & fulldeck[i].IsSC) {
				deck[n] = fulldeck[i];
				n++;
			}	
			if (n > cardPerDeck -1) {
				break;
            }
		}


		// deciding which words are audio
		for (int i = 0; i < cardPerDeck; i++) {
			if (levelDifficulty == 1) {
				deck[i].IsAudio = (LevelTypeWithDifficultyLow[i]=="A");
			} else if (levelDifficulty == 2) {
				deck[i].IsAudio = (LevelTypeWithDifficultyMed[i]=="A");
			} else {
				deck[i].IsAudio = (LevelTypeWithDifficultyHig[i]=="A");
			} 
		}

		// Shuffling again deck
		replacements = UnityEngine.Random.Range(5, 20);
	    for (int i=0; i < replacements; i++){
		    int A = UnityEngine.Random.Range(0, cardPerDeck - 1);
		    int B = UnityEngine.Random.Range(0, cardPerDeck - 1);

		    Card a = deck[A];
		    Card b = deck[B];
		    Card c = deck[A];
		    a = b;
		    b = c;

		    deck[A] = a;
		    deck[B] = b;
	    }
	}

	public void ToggleWordsC() {
		allowWordsC = !allowWordsC;
		PlayerPrefs.SetInt("GameAllowWordsC", allowWordsC?1:0);
		PlayerPrefs.Save();
	}
	public void ToggleWordsG() {
		allowWordsG = !allowWordsG;
		PlayerPrefs.SetInt("GameAllowWordsG", allowWordsC?1:0);
		PlayerPrefs.Save();
	}
	public void ToggleWordsSC() {
		allowWordsSC = !allowWordsSC;
		PlayerPrefs.SetInt("GameAllowWordsSC", allowWordsC?1:0);
		PlayerPrefs.Save();
	}

	public void SetLevelDifficulty(int levelDifficulty) {
		PlayerPrefs.SetInt("GameDifficulty", levelDifficulty);
		PlayerPrefs.Save();
	}
}

[Serializable]
public class Card
{
	public int idx;
   	public string name; 
	public bool soft;
	public Sprite artwork;
	public AudioClip clip;
	public bool IsC;
	public bool IsG;
	public bool IsSC;
	public bool IsAudio;

}



