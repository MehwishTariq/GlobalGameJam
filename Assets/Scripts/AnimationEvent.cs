using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    public void AtAnimEnd()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().destroy = true;
        GameObject.Find("Player").GetComponent<PlayerMovement>().StopMovement = false;
        
        Invoke("DestroyOff", 3f);
    }

    void DestroyOff()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().destroy = false;
        GameObject.Find("GameManager").GetComponent<GameManager>().MachineDestroyed++;

    }
}
