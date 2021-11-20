using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    Animator anim;
    public float speed = 2f;
    public bool StopMovement = false;
    public bool IsAiming = false;
   
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(StopMovement)
        {
            return;
        }
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, 0f, y);
        if(anim != null)
        {
            anim.SetBool("isAiming", IsAiming);
            anim.SetFloat("Speed", move.normalized.magnitude);
            if (IsAiming)
            {
                Vector3 animationVector = this.transform.InverseTransformDirection(move);
                var VelocityX = animationVector.x;
                var VelocityZ = animationVector.z;
                anim.SetFloat("DirectionX", VelocityX);
                anim.SetFloat("DirectionY", VelocityZ);
            }
        }
        controller.Move(move * Time.deltaTime * speed);
        if (IsAiming)
        {
            Plane p = new Plane(Vector3.up, 0f);
            float Dist;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (p.Raycast(ray, out Dist) && Input.GetMouseButton(1))
            {
                Vector3 Dir = ray.GetPoint(Dist) - transform.position;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Dir), Time.deltaTime * 5f);
            }
        }
        else
        {
            if (move != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), Time.deltaTime * 5f);
            }
        }
        
    }
}