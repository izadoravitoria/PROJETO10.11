using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControledeAudio : MonoBehaviour
{
    public int volume;
    public int VolumeSFX;
    public bool musica;
    
    public Slider VolumeSlider;
    public Slider volumeSFXSlider;
    public Toggle toggleMusica;
    public TMP_Text textoMusica;
    
    void Start()
    {
        musica = toggleMusica.isOn;
        volume = (int)VolumeSlider.value;
        VolumeSFX = (int)volumeSFXSlider.value;
    }
    
    void Update()
    {
        musica = toggleMusica.isOn;
        volume = (int)VolumeSlider.value;
        VolumeSFX = (int)volumeSFXSlider.value;

        if (musica == true)
        {
            textoMusica.text = "Ligado";
            textoMusica.color = Color.green;
        }
        else
        {
            textoMusica.text = "Desligado";
            textoMusica.color = Color.red;  
        }
    }
    
    
    
}
