using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosao : MonoBehaviour
{
    public float raioExplosao = 10.0f;
    public float forcaExplosao = 10.0f;
    public ParticleSystem efeitoExplosao;
    public int danoBomba = 50;
    AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        Invoke("Explode", 2);
    }

    public void Explode()
    {
        _audioSource.Play();
        Vector3 posicaoExplosao = transform.position;
        Collider[] colliders = Physics.OverlapSphere(posicaoExplosao, raioExplosao);
        foreach(Collider obj in colliders)
        {
            Rigidbody rg = obj.GetComponent<Rigidbody>();
            if (rg != null)
                rg.AddExplosionForce(forcaExplosao, posicaoExplosao, raioExplosao, 3.0f);
            PlayerSaude pl = obj.GetComponent<PlayerSaude>();
            if (pl != null)
                pl.retiraVida(danoBomba);
        }
        if (efeitoExplosao != null)
        {
            efeitoExplosao = Instantiate(efeitoExplosao, transform);
            efeitoExplosao.Play();
        }
        this.GetComponent<Renderer>().enabled = false;
        Destroy(this.gameObject, 1);
    }
}
