using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apanhar : MonoBehaviour
{
    GameManager _gameManager;
    public Collider Player;

    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player")) {
            transform.parent = other.transform;
            Player = other;
            Player.gameObject.tag = "PlayerComOvo";
        } else if (other.gameObject.tag.Equals("Entrega")) {
            Destroy(this.gameObject);
            Player.gameObject.tag = "Player";
            _gameManager.adicionaOvo();
        }
    }
}
