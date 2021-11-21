using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMachine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().canDestroy = true;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if(GameObject.Find("GameManager").GetComponent<GameManager>().destroy)
        {
            Debug.Log("Destroy mech");
            // for now destroy
            //GetComponent<Animator>().SetBool("Destroy", true);
            GetComponent<Animator>().Play("Shake");
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().canDestroy = false;
        }
    }
}
