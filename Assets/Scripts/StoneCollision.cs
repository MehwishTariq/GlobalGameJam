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
            Debug.Log("sleep" + other.transform.parent.name);
            //make enemy sleep for some time
            other.enabled = false;

            other.GetComponent<NavMeshAgent>().isStopped = true;
            other.GetComponent<EnemyAI>().enabled = false;
            GameObject.Find("GameManager").GetComponent<GameManager>().hitEnemies.Add(other.transform.parent.gameObject,true);
            

        }

        else
        {
            Destroy(gameObject, 2f);
        }
    }
}
