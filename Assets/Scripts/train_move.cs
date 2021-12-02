using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using UnityEngine.WSA;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class train_move : MonoBehaviour
{

    public TextMeshProUGUI LevelLabel;
    public TextMeshProUGUI QuestionLabel;
    public TextMeshProUGUI ScoreLabel;

    public Card _currentCard;

    public PathCreator pathCreator; //path che il treno seguirà
    
    //dichiaro variabili a cui associo i 2 path diversi
    public GameObject pathLeftObj; 
    public GameObject pathRightObj;
    public GameObject ResultsPanel;

    public GameObject AnswerImage;
    public GameObject AnswerWord;

    
    
    public float speed = 2;
    private float distanceTravelled;
    public EndOfPathInstruction end;
    
    private Vector3 startPosition = new Vector3(0.4f, 0, 0); //posizione iniziale trenino
    private int startTrain = 0; //serve come variabile flag per evitare che il treno parta prima di aver scelto uno dei due path
    private Quaternion offset; //per sistemare la rotazione del trenino lungo il path
    
    
    public int _levelID = 0;
    public int _levelPreviusScore = 0; // sul JSON salviamo solo lo score precedente; alla fine del gioco il currentScore sovrascrive il previousScore
    public int _levelCurrentScore = 0;
    public int _worldID = 0; // L'id del mondo/modalità è usato anche per trovare lo sfondo legato a quella modalità (EX. mondo facile: world_background_1.png ...)
    public int _currentWordIndex = 0; // va da 0 a 9 e la usiamo per ottenere la parola corrente nel livello corrente nel mondo corrente
    
        public bool V3Equal(Vector3 a, Vector3 b) //confronta variabile vector3 evitando errori di approssimazione
    {
        return Vector3.SqrMagnitude(a - b) < 0.001;
    }
    
    //variabili per input stile swipe di tinder
    //private bool tap, swipeLeft, swipeRight;
    private Vector2 startTouch, swipeDelta;
    private bool isDraging = false;
    private bool isLevelComplete = false;


    void Awake () {
        _currentWordIndex = 0;
        _levelID = GameManager.instance.currentLevel;
        _levelPreviusScore = GameManager.instance.getStarsForLevel(_levelID);
    
        /*
        QuestionLabel = FindObjectsOfType<TextMeshProUGUI>()[0];
        QuestionLabel.SetText("Domanda "+_currentWordIndex.ToString()); 
        LevelLabel = FindObjectsOfType<TextMeshProUGUI>()[3];
        LevelLabel.SetText("Livello " + _levelID.ToString());

        ScoreLabel = FindObjectsOfType<TextMeshProUGUI>()[4];
        */

    }

    
    void addCardQuestion() {
        _currentCard = DeckManager.instance.deck[_currentWordIndex];
        Debug.Log(_currentCard.name);
        //AnswerImage.Sprite = _currentCard.artwork;
        //AnswerWord.SetText(_currentCard.name);
        GameObject.Find("QuestionWord").GetComponent<UnityEngine.UI.Text>().text = _currentCard.name.ToUpper();
        GameObject.Find("QuestionImage").GetComponent<Image>().sprite = _currentCard.artwork;
        //AnswerImage
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("OPENED LEVEL SPECIAL! " + _levelID.ToString() + " - ");
        addCardQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        //tap = swipeLeft = swipeRight = false;
        
        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            //tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion

        //Calculate the distance
        swipeDelta = Vector2.zero;
        if (isDraging & startTrain == 0) //impedisce input se treno in movimento
        {
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2) Input.mousePosition - startTouch;
        }

        if (swipeDelta.magnitude > 125 & !isLevelComplete)
        {
            //which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)//swipe a sinistra
                {
                    DidSwipe(false);
                    //swipeLeft = true;
                    pathCreator = pathLeftObj.GetComponent<PathCreator>(); //cambia path
                    offset = pathCreator.path.GetRotation(1); //cambia offset
                    distanceTravelled = 0; //azzera la distanza
                    startTrain = 1; //entra nell'if di movimento del treno
                }
                else//swipe a destra
                {
                    DidSwipe(true);
                    //swipeRight = true;
                    pathCreator = pathRightObj.GetComponent<PathCreator>();
                    offset = pathCreator.path.GetRotation(1);
                    distanceTravelled = 0;
                    startTrain = 1;
                }
            }
            Reset();
        }

        //movimento effettivo del treno
        if (startTrain == 1)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, end);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, end) * offset * offset;

            if (V3Equal(transform.position, startPosition))
            {
                startTrain = 0; //riattiva possibilità input del player
                DidCompleteQuestion();
            }
        }
    }

    private void DidSwipe(bool isSoft) {
        if (_currentCard.soft == isSoft) {
            Debug.Log("DidSwipe! Correct Answer!");
        } else {
            Debug.Log("DidSwipe! Wrong Answer!");
        }

    }


    private void DidCompleteQuestion() {

        _currentWordIndex++;
        

        if (_currentWordIndex > 10) {
            DidCompleteLevel();
        } else {
            addCardQuestion();
            Debug.Log("DidCOMPLETE QUESTIOn! "+_currentWordIndex.ToString());
            QuestionLabel.SetText("Domanda "+_currentWordIndex.ToString());  
        } 
    }

    private void DidCompleteLevel() {
        isLevelComplete = true;
        Debug.Log("DidCOMPLETE Level!! "); 
        ResultsPanel.SetActive(true);

        ScoreLabel.SetText("Punti: "+_levelCurrentScore.ToString());

        if (_levelCurrentScore > 8) {
            // 3 stelle
        } else if (_levelCurrentScore > 6) {
            // 2 stelle
        } else {
            // 1 stella
        }

        GameManager.instance.setLevelStatisticsWithStars(_levelID, _levelCurrentScore);
        GameManager.instance.currentLevel = GameManager.instance.currentLevel+1;
    }
    
    IEnumerator CorutineNextLevelPlay() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(3);
    }


    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }



    public void OpenNextLevel() {
        if (isLevelComplete) {
            StartCoroutine(CorutineNextLevelPlay());

        }
        Debug.Log("OPENING NEXT LEVEL! ");
        //anotherScript.PrepareLevel(levelNumber);
        GameManager.instance.setLevelStatisticsWithStars(_levelID, _levelCurrentScore);
        if (_levelCurrentScore > 1) {
            GameManager.instance.currentLevel = GameManager.instance.currentLevel+1;
        } else {
            Debug.Log("Gioco non superato! Riprova ");
        }
        SceneManager.LoadScene(2);
    }
}