using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    private float masterVol = 0;

    public void SetMasterVol(float vol)
    {
        audioMixer.SetFloat("Master", vol);
        masterVol = vol;
    }

    public void SetMusicVol(float vol) => audioMixer.SetFloat("Music", vol);
    public void SetFXVol(float vol) => audioMixer.SetFloat("FX", vol);
    public void UnmuteMasterVol(bool unmute)
    {
        audioMixer.SetFloat("Master", unmute ? masterVol : -80);
    }
}
