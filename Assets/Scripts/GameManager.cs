using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;    

    [SerializeField] int enemyCount=0;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] int tempEnemyCount=0;
    // static int sceneIndex=0;
       
    IEnumerator Start()
    {
        yield return StartCoroutine(FindObjectOfType<fadder>().COR_fadder(true));
    }

    public void getCount()
    {
        tempEnemyCount++;
        audioSource.PlayOneShot(audioSource.clip);
        if (tempEnemyCount>=enemyCount)
        {            
            // sceneIndex++;
            //Debug.Log(SceneManager.sceneCountInBuildSettings+" game over "+SceneManager.GetActiveScene().buildIndex);  

            if (SceneManager.GetActiveScene().buildIndex+1 ==SceneManager.sceneCountInBuildSettings)
            {
                tempEnemyCount=0;                     
                // sceneIndex=1;
                StartCoroutine(SceneLoad(0));
                return;
            }     
            
            tempEnemyCount=0;                 
            StartCoroutine(SceneLoad(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    private IEnumerator SceneLoad(int index)
    {
        yield return StartCoroutine(FindObjectOfType<fadder>().COR_fadder(false));
        SceneManager.LoadScene(index);        
    }    
}
