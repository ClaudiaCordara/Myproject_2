using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip correctSound;

    public AudioClip wrongSound;
    public static audioManager instance;
    private void Awake()
    {
        if (instance != null) {
            Destroy(gameObject);
        }else{
            instance = this;
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
