using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource wing;
    public AudioMixer mixer;
    public Slider SliderMusic;
    public Slider SliderSound;
    private const string MIXER_MUSIC = "MusicVolume";
    private const string MIXER_EFFECTS = "EffectsVolume";
    public override void Awake()
    {
        base.Awake();
        SliderMusic.onValueChanged.AddListener(SetMusicVolume);
        SliderSound.onValueChanged.AddListener(SetSoundVolume);
    }
    private void SetMusicVolume(float value)
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value)*20);
        PlayerPrefs.SetFloat(MIXER_MUSIC, value);
    }
    private void SetSoundVolume(float value)
    {
        mixer.SetFloat(MIXER_EFFECTS, Mathf.Log10(value)*20);
        PlayerPrefs.SetFloat(MIXER_EFFECTS, value);
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(MIXER_MUSIC, SliderMusic.value);
        PlayerPrefs.SetFloat(MIXER_EFFECTS, SliderSound.value);
    }

}
