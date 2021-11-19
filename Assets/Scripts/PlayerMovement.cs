using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    Animator anim;
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, 0, y);
        if(move == Vector3.zero)
        {
            anim.SetBool("Walk", false);
        }
        else
        {
            anim.SetBool("Walk", true);
        }
        controller.Move(move * Time.deltaTime * speed);
        if (Input.GetMouseButtonDown(0))
        {
            float velocity = Mathf.Clamp(Input.GetAxis("Mouse X") * 10, 5, 10);
            float angle = Mathf.Clamp(Input.GetAxis("Mouse Y") * 80, 45, 80);

            Debug.Log(" velo: " + Input.GetAxis("Mouse X") + "angle " + Input.GetAxis("Mouse Y"));
            transform.GetChild(0).GetComponent<ArcCreator>().velocity = velocity;
            transform.GetChild(0).GetComponent<ArcCreator>().angle = angle; 
            transform.GetChild(0).GetComponent<ArcCreator>().RenderArc();
        }
        
    }
}
