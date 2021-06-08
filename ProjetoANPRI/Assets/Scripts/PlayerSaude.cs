using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaude : MonoBehaviour
{
    [SerializeField]
    int vida = 100;
    AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public int GetVida()
    {
        return vida;
    }

    public void adicionarVida(int valor)
    {
        vida += valor;
    }

    public void retiraVida(int valor)
    {
        vida -= valor;
        _audioSource.Play();

        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
