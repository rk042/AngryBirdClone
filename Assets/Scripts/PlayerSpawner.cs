using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{    
    [SerializeField] List<GameObject> players=new List<GameObject>();
    CameraManager cameraManager;    
    bool isFirstTime=true;
    private void Start()
    {        
        cameraManager = FindObjectOfType<CameraManager>();
        GeneratePlayer();
    }

    public void GeneratePlayer()
    {
        // GameObject gameObject1 = GameObject.FindWithTag("Player");
        // if (gameObject1 != null)
        // {
        //     return;
        // }
        
        var player = Instantiate(players[Random.Range(0, players.Count)],
                transform.position, Quaternion.identity);
        player.GetComponent<Rigidbody2D>().isKinematic=true;
        if (!isFirstTime)
        {
            cameraManager.UpdateFollow(player.transform);
        }
        isFirstTime=false;
    }
}
