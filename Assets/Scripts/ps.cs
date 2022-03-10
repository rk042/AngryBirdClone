using UnityEngine;
using System.Collections;

public class ps : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(3f);
        Destroy(gameObject);
    }    
}