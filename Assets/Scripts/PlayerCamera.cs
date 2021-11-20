using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Transform Player;

    public float Sensitivity = 2f;
    public float Distance = 10f;
    public float Height = 5f;
    public float RotationDamping = 2f;
    public float HeightDamping = 2f;
    public float ZoomRatio = 4f;
    public float DefaultFOV = 60f;
    public float VerticalAngleOffset = 5f;

    private float OffsetX = 0f;
    private float OffsetY = 0f;
    private float RotationVector;


    //initial settings
    private float InitialHeight;
    private float InitialOffsetX;
    private float InitialOffsetY;
    private float CurrentSeconds;
    private float Delay = 3f;


    // Start is called before the first frame update
    void Start()
    {
        SetInitialValues();
        Player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
       
    }

    void FixedUpdate()
    {
        OffsetY = Mathf.Clamp(OffsetY, -3f, 3f);
        RotationVector = Player.eulerAngles.y + OffsetX;
        float Acceleration = Player.GetComponent<CharacterController>().velocity.magnitude;
        Camera.main.fieldOfView = DefaultFOV + Acceleration * ZoomRatio * Time.deltaTime;

    }

    void LateUpdate()
    {
        float wantedAngle = RotationVector;
        float wantedHeight = Player.position.y + Height + OffsetY;

        float myAngle = transform.eulerAngles.y;
        float myHeight = transform.position.y;

        myAngle = Mathf.LerpAngle(myAngle, wantedAngle, RotationDamping * Time.deltaTime);
        myHeight = Mathf.LerpAngle(myHeight, wantedHeight, HeightDamping * Time.deltaTime);

        transform.position = Player.position;
        transform.position -= Vector3.forward * Distance;

        Vector3 temp = transform.position;
        temp.y = myHeight;
        transform.position = temp;

        transform.LookAt(Player.transform.position +new Vector3(0f, VerticalAngleOffset, 0f));
    }

    void SetInitialValues()
    {
        InitialHeight = Height;
        InitialOffsetX = OffsetX;
        InitialOffsetY = OffsetY;
    }
}
