using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{    
    [SerializeField] ParticleSystem psObject;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("GameController"))
        {
            DestroyAction();
        }
    }

    private void DestroyAction()
    {
        FindObjectOfType<GameManager>().getCount();
        var pstemp = Instantiate<ParticleSystem>(psObject, transform.position, Quaternion.identity);
        pstemp.Play();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("border"))
        {            
            DestroyAction();
        }
    }
}
