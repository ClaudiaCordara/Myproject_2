using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
//using UnityEngine.WSA; // crea un probelma nell'esportare il gioco come app
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class castelloScript : MonoBehaviour {
    // Start is called before the first frame update

    public GameObject DialogPanelResult;

    void Start() {
        StartCoroutine(CorutineShowOpenMenu());
    }

    // Update is called once per frame
    void Update() {
        
    }

    IEnumerator CorutineShowOpenMenu() {
        yield return new WaitForSeconds(10);
        DialogPanelResult.gameObject.SetActive(true);
    }


     public void OpenMenu() {
        Debug.Log("Asked to open MENU!");
        StartCoroutine(CorutineOpenMenu());
    }
    IEnumerator CorutineOpenMenu() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}
