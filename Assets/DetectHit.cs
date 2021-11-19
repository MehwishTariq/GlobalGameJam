using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(DestroyAfterSeconds());
        }
    }

    IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
