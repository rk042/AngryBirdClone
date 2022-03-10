using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;    
    PlayerSpawner playerSpawner;
    private void Start()
    {
        playerSpawner=FindObjectOfType<PlayerSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("border"))
        {
            Debug.Log("generate player");
            playerSpawner.GeneratePlayer();
            Destroy(gameObject);
            // EventGeneratePlayer.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        playerSound();
        StartCoroutine(DestoryTime());
    }

    IEnumerator DestoryTime()
    {
        yield return new WaitForSecondsRealtime(5f);    
        Debug.Log("generateplayer yeild");
        Destroy(gameObject);
        playerSpawner.GeneratePlayer();
        // GameObject[] gameObject1 = GameObject.FindGameObjectsWithTag("Player");
        // if (gameObject1.Length<1)
        // {            
        // EventGeneratePlayer.Invoke();
        // }
    }

    private void playerSound()
    {        
        audioSource.PlayOneShot(audioSource.clip);
    }
}
