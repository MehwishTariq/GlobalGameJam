using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Worq.AEAI.Enemy;

public class StoneCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            GetComponent<AudioSource>().Play();
            Debug.Log("sleep" + other.transform.parent.name);
            other.GetComponent<Animator>().SetBool("isHitBool", true);
            //make enemy sleep for some time
            other.enabled = false;

            other.GetComponent<NavMeshAgent>().isStopped = true;
            other.GetComponent<EnemyAI>().enabled = false;
            GameObject.Find("GameManager").GetComponent<GameManager>().hitEnemies.Add(other.transform.parent.gameObject,true);            
        }
        Destroy(this.gameObject, 0.2f);
    }
}
