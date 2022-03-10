using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float waitTime;
    [SerializeField] GameObject player;
    CinemachineVirtualCamera myCamera;

    private void Awake()
    {
        myCamera=GetComponent<CinemachineVirtualCamera>();
    }
    
    IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(waitTime);
        player=GameObject.FindGameObjectWithTag("Player");
        UpdateFollow(player.transform);
    }
    
    public void UpdateFollow(Transform follow)
    {
        myCamera.Follow=follow;
    }
}
