using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager mainAudio;

    public string music;

    FMOD.Studio.EventInstance musicEvent;

    // Start is called before the first frame update
    void Start()
    {
        //check 
        if(mainAudio != null)
        {
            DestroyImmediate(this);
        }
        else
        {
            mainAudio = this;
            DontDestroyOnLoad(gameObject);
        }

        musicEvent = FMODUnity.RuntimeManager.CreateInstance(SoundManager.mainAudio.music);
        musicEvent.start();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
