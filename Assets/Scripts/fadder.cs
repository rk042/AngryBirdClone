using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadder : MonoBehaviour
{    
    CanvasGroup group;

    private void Awake()
    {
        group=GetComponent<CanvasGroup>();
    }
    public IEnumerator COR_fadder(bool fadInOrOut)
    {    
        if (fadInOrOut)
        {
            group.alpha=1;
            while (group.alpha != 0)
            {
                yield return new WaitForSecondsRealtime(Time.deltaTime);
                group.alpha -= Time.deltaTime / 1.5f;
            }   
        }
        else
        {            
            group.alpha=0;
            while (group.alpha != 1)
            {
                yield return new WaitForSecondsRealtime(Time.deltaTime);
                group.alpha+=Time.deltaTime/1.5f;
            }
        }
    }
}
