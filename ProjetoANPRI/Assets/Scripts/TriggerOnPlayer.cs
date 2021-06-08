using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnPlayer : MonoBehaviour
{
    public GameObject _GameObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player") || other.gameObject.tag.Equals("PlayerComOvo"))
        {
            SpawnEgg();
        }
    }

    private void SpawnEgg()
    {
        Instantiate(_GameObject, transform.position, transform.rotation);
    }
}
