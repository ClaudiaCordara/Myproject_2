using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MainMenu : MonoBehaviour {
    // Start is called before the first frame update

    public GameObject imageObject;
    public void Start() {
        Debug.Log(PlayerPrefs.HasKey("GameAllowWordsC"));
        if (!PlayerPrefs.HasKey("GameAllowWordsC")) {
            ResetGame();
        }
        UpdateStarsLabel();
        PlayerPrefs.SetInt("GameShouldHideTutorial", 0); 

        if (PlayerPrefs.GetInt("GameTotalStars") > 30) {
            GameObject.Find("PrincipeImage").GetComponent<Image>().sprite = Resources.Load<Sprite>("QPrincipeN1");
            GameObject.Find("PrincipeOptionsImage").GetComponent<Image>().sprite = Resources.Load<Sprite>("QPrincipeI1");
        }
    }
    public void ResetGame() {
        PlayerPrefs.SetInt("GameAllowWordsC", 1);
        PlayerPrefs.SetInt("GameAllowWordsG", 1);
        PlayerPrefs.SetInt("GameAllowWordsSc", 1);
        PlayerPrefs.SetInt("GameDifficulty", 1);
        PlayerPrefs.SetInt("TotalStarsLabel", 0);
        PlayerPrefs.SetInt("GameTotalStars", 0);
        PlayerPrefs.SetInt("GameShouldHideTutorial", 0);
        PlayerPrefs.Save();
    }
    public void UpdateStarsLabel() {	
        GameObject.Find("TotalStarsLabel").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("GameTotalStars").ToString();	
    }

    public void PlayGame() {
        DeckManager.instance.Shuffle();
        StartCoroutine(CorutineOpenNextLevel());
    }

    public void OpenCredits() {
        StartCoroutine(CorutineOpenCredits());
    }
    IEnumerator CorutineOpenCredits() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(3);
    }
    IEnumerator CorutineOpenNextLevel() {
        yield return new WaitForSeconds(1);
        GameManager.instance.currentLevel = 1;
        SceneManager.LoadScene(2);
    }

    public void ToggleWordsC() {
        DeckManager.instance.ToggleWordsC();
        syncToggleWords();
    }
    public void ToggleWordsG() {
        DeckManager.instance.ToggleWordsG();
        syncToggleWords();
    }
    public void ToggleWordsSC() {
        DeckManager.instance.ToggleWordsSC();
        syncToggleWords();
    }

    public void OnValueChanged(float input)
    {
        int levelDifficulty = (int)input;
        DeckManager.instance.SetLevelDifficulty(levelDifficulty);
    }

    public void syncToggleWords()
    {
        if (!DeckManager.instance.allowWordsC & !DeckManager.instance.allowWordsG & !DeckManager.instance.allowWordsSC)
        {
            ToggleWordsC();
            ToggleWordsG();
            ToggleWordsSC();
        }

        GameObject.Find("enableCcb").GetComponent<Image>().sprite = Resources.Load<Sprite>("checkbox-"+(DeckManager.instance.allowWordsC?"true":"false"));
        GameObject.Find("enableGcb").GetComponent<Image>().sprite = Resources.Load<Sprite>("checkbox-" + (DeckManager.instance.allowWordsG ? "true" : "false"));
        GameObject.Find("enableSCcb").GetComponent<Image>().sprite = Resources.Load<Sprite>("checkbox-" + (DeckManager.instance.allowWordsSC ? "true" : "false"));
        GameObject.Find("DifficultySlider").GetComponent<Slider>().value = DeckManager.instance.levelDifficulty;
    }


    public void openCreditsPage() {
        UnityEngine.Application.OpenURL("https://www.andreacarpi.it/pprojects/Il-Principe-dei-Suoni/?from=unityapp");
    }
}
