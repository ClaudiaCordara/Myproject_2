using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour {
    // Start is called before the first frame update

    public void Start() {
        Debug.Log("Is first aa " );
        Debug.Log(PlayerPrefs.HasKey("GameTotalStars"));
        if (!PlayerPrefs.HasKey("GameAllowWordsC")) {
            PlayerPrefs.SetInt("GameAllowWordsC", 1);
            PlayerPrefs.SetInt("GameAllowWordsG", 1);
            PlayerPrefs.SetInt("GameAllowWordsSc", 1);
            PlayerPrefs.SetInt("GameDifficulty", 1);
            PlayerPrefs.SetInt("GameTotalStars", 0);
            PlayerPrefs.Save();
        }
    }


    public void PlayGame() {
        DeckManager.instance.Shuffle();
        StartCoroutine(CorutineOpenNextLevel());
    }

    public void LevelsGame() {
        StartCoroutine(CorutineOpenLevels());
    }
    IEnumerator CorutineOpenLevels() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
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
        GameManager.instance.currentLevel = GameManager.instance.currentLevel + 1;
        SceneManager.LoadScene(4);
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
}
