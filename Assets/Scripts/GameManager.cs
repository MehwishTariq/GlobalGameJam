using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Worq.AEAI.Enemy;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerMovement player;
    [SerializeField] GameObject machineCanvas;
    public Dictionary<GameObject, bool> hitEnemies = new Dictionary<GameObject, bool>();

    public bool stoneCollided { get; set; }
    public int TotalMachines;

    public bool canDestroy { get; set; }
    public bool destroy { get; set; }

    bool Wait = false;
    public int MachineDestroyed { get; set; }

    private void Start()
    {
        stoneCollided = false;
        machineCanvas.SetActive(false);
    }

    IEnumerator WakeEnemyUp(GameObject enemy)
    {
        Debug.Log("hello");
        yield return new WaitForSeconds(20f);
        Debug.Log("hello2");
        enemy.GetComponentInChildren<NavMeshAgent>().isStopped = false;
        enemy.GetComponentInChildren<EnemyAI>().enabled = true;
        enemy.GetComponentInChildren<CapsuleCollider>().enabled = true;
    }

    private void Update()
    {
        if (hitEnemies.Count > 0)
        {
            foreach (var x in hitEnemies)
            {
                if (x.Value == true)
                {
                    hitEnemies[x.Key] = false;
                    StartCoroutine(WakeEnemyUp(x.Key));
                }
            }
        }

        

        if (TotalMachines == MachineDestroyed)
        {
            player.StopMovement = true;
            Time.timeScale = 0;
            Debug.Log("LevelComplete");
            //Level complete screen show
        }
        else
        {
            
            if (canDestroy)
            {
               
                machineCanvas.SetActive(true);
               if (Input.GetKey(KeyCode.Space))
               {
                    Wait = true;
                    if (Wait)
                    {
                        canDestroy = false;
                        player.StopMovement = true;
                        Debug.Log("animPlay");
                        player.transform.GetComponentInChildren<Animator>().Play("Destroy");
                        Wait = false;
                    }
                }
            }
            else
            {
                machineCanvas.SetActive(false);
            }


        }
    }




}
