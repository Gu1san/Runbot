using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerController : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider fxVol;
    public Slider musicVol;
    public Slider masterVol;
    void Start()
    {
        
    }

    public void ChangeMasterVol()
    {
        mixer.SetFloat("MasterVol", masterVol.value);
    }
    public void ChangeMusicVol()
    {
        mixer.SetFloat("MusicVol", musicVol.value);
    }

    public void ChangeFXVol()
    {
        mixer.SetFloat("FXVol", fxVol.value);
    }
}
