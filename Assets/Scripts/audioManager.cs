// CLA SCUSA MA MI Dé ERRORE
// Assets/Scripts/audioManager.cs(4,7): error CS0246: The type or namespace name 'UnityEditorInternal' could not be found (are you missing a using directive or an assembly reference?)



using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    private AudioSource audiosource;

    public AudioClip correctSound;

    public AudioClip wrongSound;
    public static audioManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        audiosource = GetComponent<AudioSource>();
    }

    public void PlayCorrect()
    {
        audiosource.PlayOneShot(correctSound);
    }

    public void PlayWrong()
    {
        audiosource.PlayOneShot(wrongSound);
    }

}
