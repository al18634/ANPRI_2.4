using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerirColisoes : MonoBehaviour
{
    [SerializeField]
    int tiraVida = 10;
    [SerializeField]
    float intervalo = 3;
    [SerializeField]
    float ultimaVezPerda = 0;

    private void OnTriggerEnter(Collider other)
    {
        RetirarVida(other);
    }

    private void OnTriggerStay(Collider other)
    {
        if (ultimaVezPerda + intervalo < Time.time)
        {
            RetirarVida(other);
        }
    }

    private void RetirarVida(Collider other)
    {
        var temp = other.transform.GetComponent<PlayerSaude>() as PlayerSaude;
        if (temp != null)
        {
            temp.retiraVida(tiraVida);
            ultimaVezPerda = Time.time;
        }
    }
}
