using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrow : MonoBehaviour
{
    [SerializeField] List<GameObject> projectTileList=new List<GameObject>();
    [SerializeField] float throwForce, throwForceProjectile,projectTileGravityScale;
    [SerializeField] private AudioSource audioSource;

    Rigidbody2D rd;
    Vector2 startPosition;
    bool isShooting=false;
    bool isthrowed=false;
    private void Awake()
    {
        rd=GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rd.isKinematic=true;
        foreach (Transform item in FindObjectOfType<PlayerSpawner>().transform)
        {
            projectTileList.Add(item.gameObject);
        }
        foreach (var item in projectTileList)
        {
            item.GetComponent<Renderer>().enabled=false;            
        }
    }

    private void Update()
    {
        if(Input.GetAxis("Fire1")==1 && !isthrowed)
        {
            if (!isShooting)
            {
                isShooting=true;
                startPosition=Input.mousePosition;
            }
            else
            {
                for (int i = 0; i < projectTileList.Count-3; i++)
                {
                    projectTileList[i].GetComponent<Renderer>().enabled=true;
                    projectTileList[i].transform.position=projectTilePath(transform.position,GetFroceProjectile(),i);
                }
            }
        }
        else if(isShooting && !isthrowed)
        {
            rd.isKinematic=false;
            playerSound();
            rd.AddForce(GetFroce());
            isthrowed=true;
            isShooting=false;
            // for (int i = 0; i < projectTileList.Count; i++)
            // {
            //     projectTileList[i].GetComponent<Renderer>().enabled=false;
            // }
        }
    }

    private void playerSound()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    private Vector2 GetFroce()
    {
        return (new Vector2(startPosition.x,startPosition.y)- new Vector2(Input.mousePosition.x,Input.mousePosition.y)) * throwForce;
    }
    private Vector2 GetFroceProjectile()
    {
        return (new Vector2(startPosition.x,startPosition.y)- new Vector2(Input.mousePosition.x,Input.mousePosition.y)) * throwForceProjectile;
    }

    private Vector2 projectTilePath(Vector2 startPath,Vector2 velocity,int index)
    {
        return startPath + velocity * index *Time.fixedDeltaTime + GetFroceProjectile() *Time.fixedDeltaTime + projectTileGravityScale* Physics2D.gravity *index*index; //velocity *Time.fixedDeltaTime*index;
    }
}
