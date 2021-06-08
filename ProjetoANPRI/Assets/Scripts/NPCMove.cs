using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : MonoBehaviour
{
    public Transform[] pontos;
    public int velocidade;

    private int proximoPonto;
    private float dist;

    // Start is called before the first frame update
    void Start()
    {
        proximoPonto = 0;
        transform.LookAt(pontos[proximoPonto].position);
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position, pontos[proximoPonto].position);
        if (dist < 1f)
        {
            IncreaseIndex();
        }
        Patrol();
    }

    void Patrol()
    {
        transform.Translate(Vector3.forward * velocidade * Time.deltaTime);
    }

    void IncreaseIndex()
    {
        proximoPonto++;
        if (proximoPonto >= pontos.Length)
        {
            proximoPonto = 0;
        }
        transform.LookAt(pontos[proximoPonto].position);
    }
}
