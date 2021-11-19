using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMovement : MonoBehaviour
{
    public float rotationSpeed = 1;
    public float BlastPower = 5;

    public GameObject Stone;
    public Transform ShotPoint;

    void Update()
    {
       
        if (Input.GetMouseButton(0))
        {

            float HorizontalRotation = Input.GetAxis("Mouse X");
            float VericalRotation = Input.GetAxis("Mouse Y");

            ShotPoint.rotation = Quaternion.Euler(ShotPoint.rotation.eulerAngles +
                new Vector3(0, 0, VericalRotation * rotationSpeed)); 
            BlastPower = Mathf.Clamp(BlastPower + HorizontalRotation * rotationSpeed,5,10);
            Debug.Log(HorizontalRotation * rotationSpeed);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject CreatedStone = Instantiate(Stone, ShotPoint.position, ShotPoint.rotation);
                CreatedStone.GetComponent<Rigidbody>().velocity = ShotPoint.transform.right * BlastPower;

            }
        }
    }
}
