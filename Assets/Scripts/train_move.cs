using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
//using UnityEngine.WSA; // crea un probelma nell'esportare il gioco come app
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class train_move : MonoBehaviour
{

    public Card _currentCard;

    public PathCreator pathCreator; //path che il treno seguirà
    
    //dichiaro variabili a cui associo i 2 path diversi
    public GameObject pathLeftObj; 
    public GameObject pathRightObj;

    public GameObject AnswerImage;
    public GameObject AnswerWord;

    public GameObject DialogPanel;
    public GameObject DialogPanelResult;
    
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
    private bool isPuppetSpeaking = false;
    private int puppetStatus = 0;

    void Awake () {
        _currentWordIndex = 0;
        _levelID = GameManager.instance.currentLevel;
        _levelPreviusScore = GameManager.instance.getStarsForLevel(_levelID);

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
    void Start() {
        Debug.Log("OPENED LEVEL SPECIAL! " + _levelID.ToString() + " - ");
        addCardQuestion();

        PlayerPrefs.SetInt("GameShouldHideTutorial", 0);
        if (PlayerPrefs.GetInt("GameShouldHideTutorial")==0) {
            DialogPanel.SetActive(true);
        } else {
            DialogPanel.SetActive(false);
        }
    }

    // Update is called once per frame
    private float nextActionTime = 0.0f;
    public float period = 0.2f;
    int animationStep = 0;
    void Update() {
        if (Time.time > nextActionTime ) {
            nextActionTime += period;
            // execute block of code here
            if (DialogPanel.activeSelf) {
                if (isPuppetSpeaking) {
                    if (puppetStatus == -1) {
                        GameObject.Find("PrincipeDeiSuoniDialog").GetComponent<Image>().sprite = Resources.Load<Sprite>("PrincipeDeiSuoni_base_wrong");
                    } else if (puppetStatus == 1) {
                        GameObject.Find("PrincipeDeiSuoniDialog").GetComponent<Image>().sprite = Resources.Load<Sprite>("PrincipeDeiSuoni_base_correct");
                    } else {
                        GameObject.Find("PrincipeDeiSuoniDialog").GetComponent<Image>().sprite = Resources.Load<Sprite>("PrincipeDeiSuoni_base");
                    }
                } else {
                    if (puppetStatus == -1) {
                        GameObject.Find("PrincipeDeiSuoniDialog").GetComponent<Image>().sprite = Resources.Load<Sprite>("PrincipeDeiSuoni_O_wrong");
                    } else if (puppetStatus == 1) {
                        GameObject.Find("PrincipeDeiSuoniDialog").GetComponent<Image>().sprite = Resources.Load<Sprite>("PrincipeDeiSuoni_O_correct");
                    } else {
                        GameObject.Find("PrincipeDeiSuoniDialog").GetComponent<Image>().sprite = Resources.Load<Sprite>("PrincipeDeiSuoni_O");
                    }
                }
            } else if (DialogPanelResult.activeSelf) {
                if (isPuppetSpeaking) {
                    GameObject.Find("PrincipeDeiSuoniDialogResult").GetComponent<Image>().sprite = Resources.Load<Sprite>("PrincipeDeiSuoni_superhappy_base");
                } else {
                    GameObject.Find("PrincipeDeiSuoniDialogResult").GetComponent<Image>().sprite = Resources.Load<Sprite>("PrincipeDeiSuoni_superhappy_O");
                }
            }
            animationStep++;
            if (animationStep%5== 0 || animationStep%4==0) {
                isPuppetSpeaking = !isPuppetSpeaking;
            }
            if (animationStep > 999) { animationStep = 0; }
        }



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
            if ((Mathf.Abs(x) > Mathf.Abs(y)) & startTrain == 0)
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

    bool lastSwipeWasSoft = false;
    private void DidSwipe(bool isSoft) {
        lastSwipeWasSoft = isSoft;
        DialogPanel.SetActive(true);
       if (_currentCard.soft == isSoft) {
            audioManager.instance.PlayCorrect();
            Debug.Log("DID COMPLETEQUESTION! DidSwipe! Correct Answer!");
            puppetStatus = 1;
            GameObject.Find("TextDialogLabel").GetComponent<TextMeshProUGUI>().text = "Risposta corretta! La parola “"+_currentCard.name+"” è "+(_currentCard.soft?"dolce":"dura")+". \nContinua così!";
        } else {
            audioManager.instance.PlayWrong();
            Debug.Log("DID COMPLETEQUESTION! DidSwipe! Wrong Answer!");
            puppetStatus = -1;
            GameObject.Find("TextDialogLabel").GetComponent<TextMeshProUGUI>().text = "Risposta sbagliata! La parola “"+_currentCard.name+"” è "+(_currentCard.soft?"dolce":"dura")+". \nNon mollare!";
            Handheld.Vibrate(); // Facciamo vibrare il dispositivo quando si verifica un errore // Dalla letteratura è utile inserire feedback aptici!
        }
        DialogPanel.SetActive(false);
    }


    private void DidCompleteQuestion() {
        DialogPanel.SetActive(true);
        _currentWordIndex++;
        if (_currentWordIndex < 10) {
            addCardQuestion();
            Debug.Log("DidCOMPLETE QUESTIOn! "+_currentWordIndex.ToString()); 
        } 
    }

    private void DidCompleteLevel() {
        isLevelComplete = true;
        Debug.Log("DidCOMPLETE Level!! "); 
        DialogPanelResult.SetActive(true);

        if (_levelCurrentScore > 8) {
            // 3 stelle
            GameObject.Find("StarsImage").GetComponent<Image>().sprite = Resources.Load<Sprite>("stars3");
        } else if (_levelCurrentScore > 6) {
            // 2 stelle
            GameObject.Find("StarsImage").GetComponent<Image>().sprite = Resources.Load<Sprite>("stars2");
        } else if (_levelCurrentScore > 4) {
            // 1 stella
            GameObject.Find("StarsImage").GetComponent<Image>().sprite = Resources.Load<Sprite>("stars1");
        } else {
            GameObject.Find("StarsImage").GetComponent<Image>().sprite = Resources.Load<Sprite>("stars0");
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

    public void closeDialog() {
        if (_currentWordIndex == 0) {
            if (PlayerPrefs.GetInt("GameShouldHideTutorial")==0) {
                GameObject.Find("TextDialogLabel").GetComponent<TextMeshProUGUI>().text = "Scorri a destra se una parola è dolce, invece scorri a sinistra se una parola è dura!";
                PlayerPrefs.SetInt("GameShouldHideTutorial", 1);
                PlayerPrefs.Save();
            } else {
                DialogPanel.SetActive(false);
            }
        } else {
             DialogPanel.SetActive(false);
             if (_currentWordIndex > 9) {
                DidCompleteLevel();
            }
        }
    }

    public void OpenMenu() {
        StartCoroutine(CorutineOpenMenu());
    }
    IEnumerator CorutineOpenMenu() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }

    public void OpenLevelAtIndex(int levelNumber) {
        Debug.Log("OPENING LEVEL AT INDEX "+levelNumber);
        DeckManager.instance.Shuffle();
        StartCoroutine(CorutineOpenLevel(levelNumber));
    }

    IEnumerator CorutineOpenLevel(int levelNumber) {
        yield return new WaitForSeconds(1);
        GameManager.instance.currentLevel = levelNumber;
        SceneManager.LoadScene(2);
    }
}