using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdicionarVida : MonoBehaviour
{
    [SerializeField]
    int adicionaVida = 10;
    [SerializeField]
    float intervalo = 3;
    [SerializeField]
    float ultimaVezAdicionado = 0;

    private void OnTriggerEnter(Collider other)
    {
        Adiciona(other);
    }

    private void OnTriggerStay(Collider other)
    {
        if (ultimaVezAdicionado + intervalo < Time.time)
        {
            Adiciona(other);
        }
    }

    private void Adiciona(Collider other)
    {
        var temp = other.transform.GetComponent<PlayerSaude>() as PlayerSaude;
        if (temp != null)
        {
            temp.adicionarVida(adicionaVida);
            ultimaVezAdicionado = Time.time;
        }
    }
}
