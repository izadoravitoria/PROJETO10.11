using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ControleDeAudio : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Text textoMaster;
    public Slider sliderMaster;
    public TMP_Text textoSFX;
    public Slider sliderSFX;
    public TMP_Text textoMusica;
    public Slider sliderMusica;

    private float masterVolume = 0f;
    private float sfxVolume = 0f;
    private float musicaVolume = 0f;

    private const string PARAM_MASTER = "MASTER"; 
    private const string PARAM_SFX = "SFX";
    private const string PARAM_MUSICA = "MUSICA";

    void Awake()
    {
        audioMixer.GetFloat(PARAM_MASTER, out masterVolume);
        sliderMaster.value = masterVolume;
        SetMasterVolume(masterVolume);

        audioMixer.GetFloat(PARAM_SFX, out sfxVolume);
        sliderSFX.value = sfxVolume;
        SetSFXVolume(sfxVolume);

        audioMixer.GetFloat(PARAM_MUSICA, out musicaVolume); 
        sliderMusica.value = musicaVolume;
        SetMusicVolume(musicaVolume);
        
        sliderMaster.onValueChanged.AddListener(SetMasterVolume);
        sliderSFX.onValueChanged.AddListener(SetSFXVolume);
        sliderMusica.onValueChanged.AddListener(SetMusicVolume);
    }

    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;
        if (masterVolume <= -20)
            audioMixer.SetFloat(PARAM_MASTER, -80f);
        else
            audioMixer.SetFloat(PARAM_MASTER, masterVolume);

        textoMaster.text = masterVolume.ToString("F1");
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        if (sfxVolume <= -20)
            audioMixer.SetFloat(PARAM_SFX, -80f);
        else
            audioMixer.SetFloat(PARAM_SFX, sfxVolume);

        textoSFX.text = sfxVolume.ToString("F1");
    }

    public void SetMusicVolume(float volume)
    {
        musicaVolume = volume;
        if (musicaVolume <= -20)
            audioMixer.SetFloat(PARAM_MUSICA, -80f);
        else
            audioMixer.SetFloat(PARAM_MUSICA, musicaVolume);

        textoMusica.text = musicaVolume.ToString("F1");
    }
}