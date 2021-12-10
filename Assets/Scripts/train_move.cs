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
    
    const float StartSpeed = 3.0f;    
    public float speed = StartSpeed;
    public float distanceTravelled;
    private int flagCardUpdate = 1;
    public EndOfPathInstruction end;
    
    private Vector3 startPosition = new Vector3(0.4f, 0, 0); //posizione iniziale trenino
    public bool trainIsMoving = false; //serve come variabile flag per evitare che il treno parta prima di aver scelto uno dei due path
    private Quaternion offset; //per sistemare la rotazione del trenino lungo il path
    
    public bool ShouldShowHoverlayOnCorrectAnswer = true;
    public bool ShouldOpenHoverlay = false;
    public int _levelID = 0;
    public int _levelPreviusScore = 0; // sul JSON salviamo solo lo score precedente; alla fine del gioco il currentScore sovrascrive il previousScore
    public int _levelCurrentScore = 0;
    public int _worldID = 0; // L'id del mondo/modalità è usato anche per trovare lo sfondo legato a quella modalità (EX. mondo facile: world_background_1.png ...)
    public int _currentWordIndex = 0; // va da 0 a 9 e la usiamo per ottenere la parola corrente nel livello corrente nel mondo corrente
    

    public bool shouldPlayWord = false;
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
    private string imagePrefix = "";

    void Awake () {
        _currentWordIndex = 0;
        _levelID = GameManager.instance.currentLevel;
        _levelPreviusScore = GameManager.instance.getStarsForLevel(_levelID);

    }
   
    // Start is called before the first frame update
    void Start() {
        Debug.Log("OPENED LEVEL SPECIAL! " + _levelID.ToString() + " - ");
        ShouldShowHoverlayOnCorrectAnswer = true;
        
        imagePrefix = (PlayerPrefs.GetInt("GameTotalStars")>=30)?"Q":"";

        addCardQuestion();
        StartCoroutine(CorutineAddCardQuestion());
        UpdateStarsLabel();

        if (PlayerPrefs.GetInt("GameShouldHideTutorial")==0) {
            DialogPanel.SetActive(true);
        } else {
            DialogPanel.SetActive(false);
        }
    }
    
    IEnumerator CorutineAddCardQuestion() {
        yield return new WaitForSeconds(1);
        if (_currentCard.IsAudio) //in caso l'audio fosse la prima parola da indovinare
        {
            audioManager.instance.PlaySoundCard(_currentCard.clip);
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
                        GameObject.Find("PrincipeDeiSuoniDialog").GetComponent<Image>().sprite = Resources.Load<Sprite>(imagePrefix+"PrincipeS1");
                    } else if (puppetStatus == 1) {
                        GameObject.Find("PrincipeDeiSuoniDialog").GetComponent<Image>().sprite = Resources.Load<Sprite>(imagePrefix+"PrincipeN1");
                    } else {
                        GameObject.Find("PrincipeDeiSuoniDialog").GetComponent<Image>().sprite = Resources.Load<Sprite>(imagePrefix+"PrincipeN1");
                    }
                } else {
                    if (puppetStatus == -1) {
                        GameObject.Find("PrincipeDeiSuoniDialog").GetComponent<Image>().sprite = Resources.Load<Sprite>(imagePrefix+"PrincipeS2");
                    } else if (puppetStatus == 1) {
                        GameObject.Find("PrincipeDeiSuoniDialog").GetComponent<Image>().sprite = Resources.Load<Sprite>(imagePrefix+"PrincipeN2");
                    } else {
                        GameObject.Find("PrincipeDeiSuoniDialog").GetComponent<Image>().sprite = Resources.Load<Sprite>(imagePrefix+"PrincipeN3");
                    }
                }
            } else if (DialogPanelResult.activeSelf) {
                if (puppetStatus == -1) {
                    if (isPuppetSpeaking) {
                        GameObject.Find("PrincipeDeiSuoniDialogResult").GetComponent<Image>().sprite = Resources.Load<Sprite>(imagePrefix+"PrincipeS1");
                    } else {
                        GameObject.Find("PrincipeDeiSuoniDialogResult").GetComponent<Image>().sprite = Resources.Load<Sprite>(imagePrefix+"PrincipeS2");
                    }
                } else {
                    if (isPuppetSpeaking) {
                        GameObject.Find("PrincipeDeiSuoniDialogResult").GetComponent<Image>().sprite = Resources.Load<Sprite>(imagePrefix+"PrincipeH1");
                    } else {
                        GameObject.Find("PrincipeDeiSuoniDialogResult").GetComponent<Image>().sprite = Resources.Load<Sprite>(imagePrefix+"PrincipeH2");
                    }
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
        if (Input.GetMouseButtonDown(0)) {
            //tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        } else if (Input.GetMouseButtonDown(0)) {
            isDraging = false;
            Reset();
        }
        #endregion

        //Calculate the distance
        swipeDelta = Vector2.zero;
        if (isDraging & !trainIsMoving) //impedisce input se treno in movimento
        {
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2) Input.mousePosition - startTouch;
        }



        if (swipeDelta.magnitude > 25 & !isLevelComplete & !trainIsMoving) {
            //which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y)) {
                if (x < 0)//swipe a sinistra
                {
                    trainIsMoving = true;
                    DidSwipe(false);
                    pathCreator = pathLeftObj.GetComponent<PathCreator>(); //cambia path
                    offset = pathCreator.path.GetRotation(1); //cambia offset
                    distanceTravelled = 0; //azzera la distanza
                }
                else//swipe a destra
                {
                    trainIsMoving = true;
                    DidSwipe(true);
                    pathCreator = pathRightObj.GetComponent<PathCreator>();
                    offset = pathCreator.path.GetRotation(1);
                    distanceTravelled = 0;
                }
            }
            Reset();
        }
        

        //movimento effettivo del treno
        if (trainIsMoving) {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, end);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, end) * offset * offset;
            
            if (Input.GetMouseButtonDown(0) && (speed < 6.0f)) {
                speed += 1;
            }
            
            //aggiorna la carta subito dopo che il treno sorpassa il bivio
            if (distanceTravelled > 5 && flagCardUpdate == 1) {
                DidCompleteQuestion();
                flagCardUpdate = 0;
            }

            if (distanceTravelled > 25) {
                if (_currentWordIndex < 10 & _currentWordIndex > 0) {
                    closeDialog();
                }
            }
            
            if (V3Equal(transform.position, startPosition)) {
                trainIsMoving = false; //riattiva possibilità input del player
                flagCardUpdate = 1;
                speed = StartSpeed;
                Debug.Log("Back tos tart position! "+_currentCard.IsAudio.ToString());
                if (_currentCard.IsAudio && shouldPlayWord) {   
                    audioManager.instance.PlaySoundCard(_currentCard.clip);
                    shouldPlayWord = false;
                }
            }
        }
    }

    void addCardQuestion() {
        _currentCard = DeckManager.instance.deck[_currentWordIndex];
        Debug.Log(_currentCard.name);
        //faccio le stesse cose di prima programmate da Andrea, ma LEGGE la parola nella funzione "update()" OK! Ho aggiunto epr evitare che la parola venisse riprodotta all'infinito
        if (_currentCard.IsAudio)
        {
            shouldPlayWord = true;
            GameObject.Find("QuestionWord").GetComponent<UnityEngine.UI.Text>().text = "Ascolta la parola!";
            GameObject.Find("QuestionImage").GetComponent<Image>().sprite = Resources.Load<Sprite>("speaker");
        }else{
            GameObject.Find("QuestionWord").GetComponent<UnityEngine.UI.Text>().text = _currentCard.name.ToUpper();
            GameObject.Find("QuestionImage").GetComponent<Image>().sprite = _currentCard.artwork;
        }
    }


    bool lastSwipeWasSoft = false;
    private void DidSwipe(bool isSoft) {
        lastSwipeWasSoft = isSoft;
        DialogPanel.SetActive(true);
       if (_currentCard.soft == isSoft) {
            Debug.Log("DID COMPLETEQUESTION! DidSwipe! Correct Answer!");
            _levelCurrentScore++;
            puppetStatus = 1;
            GameObject.Find("TextDialogLabel").GetComponent<TextMeshProUGUI>().text = "Risposta corretta! La parola “"+_currentCard.name+"” è una parola "+(_currentCard.soft?"dolce":"dura")+". \nContinua così!";
            audioManager.instance.PlayCorrect();
            ShouldOpenHoverlay = false;
            if (ShouldShowHoverlayOnCorrectAnswer) {
                ShouldOpenHoverlay = true;
                ShouldShowHoverlayOnCorrectAnswer = false;
            }
        } else {
            ShouldOpenHoverlay = true;
            Debug.Log("DID COMPLETEQUESTION! DidSwipe! Wrong Answer!");
            puppetStatus = -1;
            GameObject.Find("TextDialogLabel").GetComponent<TextMeshProUGUI>().text = "Oh, risposta sbagliata. “"+_currentCard.name+"” è una parola "+(_currentCard.soft?"dolce":"dura")+". \n Forza, non mollare!";
            audioManager.instance.PlayWrong();
            Handheld.Vibrate(); // Facciamo vibrare il dispositivo quando si verifica un errore // Dalla letteratura è utile inserire feedback aptici!
        }
        DialogPanel.SetActive(false);
    }


    private void DidCompleteQuestion() {
        _currentWordIndex++;	
        if (_currentWordIndex < 10) {	
           GameObject.Find("QuestionIndexLabel").GetComponent<TextMeshProUGUI>().text = (_currentWordIndex+1).ToString()+"/10";	
        }
        if (ShouldOpenHoverlay) {
            ShouldOpenHoverlay = false;
            DialogPanel.SetActive(true);
        }
        if (_currentWordIndex < 10) {
            addCardQuestion();
            Debug.Log("DidCOMPLETE QUESTIOn! "+_currentWordIndex.ToString()); 
        } else {
            DidCompleteLevel();
        }
    }

    private void DidCompleteLevel() {
        if (!isLevelComplete) {
            isLevelComplete = true;
            Debug.Log("DidCOMPLETE Level!! "); 
            DialogPanelResult.SetActive(true);

            int gainedStars = 0;
            if (_levelCurrentScore > 8) {
                // 3 stelle
                gainedStars = 3;
                GameObject.Find("StarsImage").GetComponent<Image>().sprite = Resources.Load<Sprite>("3S");
            } else if (_levelCurrentScore > 6) {
                // 2 stelle
                gainedStars = 2;
                GameObject.Find("StarsImage").GetComponent<Image>().sprite = Resources.Load<Sprite>("2S");
            } else if (_levelCurrentScore > 4) {
                // 1 stella
                gainedStars = 1;
                GameObject.Find("StarsImage").GetComponent<Image>().sprite = Resources.Load<Sprite>("1S");
            } else {
                GameObject.Find("StarsImage").GetComponent<Image>().sprite = Resources.Load<Sprite>("0S");
            }

            PlayerPrefs.SetInt("GameTotalStars" , PlayerPrefs.GetInt("GameTotalStars") + gainedStars);	
            PlayerPrefs.Save();
            int remainingStars = 30-PlayerPrefs.GetInt("GameTotalStars");
            if (remainingStars > 0) {
                if (_levelCurrentScore > 4) {
                    GameObject.Find("TextResultLabel").GetComponent<TextMeshProUGUI>().text = "Complimenti! Ce la hai fatta. Altre "+remainingStars.ToString()+" stelle e sarò Re!";
                } else {
                    puppetStatus = -1;
                    GameObject.Find("TextResultLabel").GetComponent<TextMeshProUGUI>().text = "Anche i Re possono sbagliare!";
                }
            } else {
                if (_levelCurrentScore > 4) {
                    puppetStatus = 1;
                    GameObject.Find("TextResultLabel").GetComponent<TextMeshProUGUI>().text = "Un vero Re non smette mai di perfezionarsi!";
                } else {
                    puppetStatus = -1;
                    GameObject.Find("TextResultLabel").GetComponent<TextMeshProUGUI>().text = "Anche i Re possono sbagliare!";
                }
            }
            Debug.Log("Hai guadagnato "+gainedStars.ToString()+" - "+_levelCurrentScore.ToString());	
            
            UpdateStarsLabel();

            GameManager.instance.setLevelStatisticsWithStars(_levelID, _levelCurrentScore);
            GameManager.instance.currentLevel = GameManager.instance.currentLevel+1;
        }
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

    public void UpdateStarsLabel() {	
        GameObject.Find("TotalStarsLabel").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("GameTotalStars").ToString();	
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