using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleScript : MonoBehaviour
{
    public AudioSource Musica;
    public Toggle toggleAudio;

    private void ToggleMusic(bool Value)
    {
        if (Value == true)
        {
            Musica.Play();
        }
        else
        {
            Musica.Stop();
        }
    }

    private bool ReturnToggleValue()
    {
        return (toggleAudio.isOn);
    }

    void Start()
    {
        ToggleMusic(ReturnToggleValue());

        toggleAudio.onValueChanged.AddListener(delegate
        {
            ToggleMusic(ReturnToggleValue());
        });
    }
}
