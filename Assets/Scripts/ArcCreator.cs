using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcCreator : MonoBehaviour
{
    LineRenderer lr;

    float g; //force of gravity on the y axis
    StoneMovement stoneMove;
    
    // Number of points on the line
    public int numPoints = 10;

    // distance between those points on the line
    public float timeBetweenPoints = 0.1f;

    // The physics layers that will cause the line to stop being drawn
    public LayerMask CollidableLayers;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        stoneMove = GetComponent<StoneMovement>();
        g = Mathf.Abs(Physics2D.gravity.y);
    }


    private void Update()
    {
        lr.positionCount = (int)numPoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 startingPosition = stoneMove.ShotPoint.position;
        Vector3 startingVelocity = stoneMove.ShotPoint.right * stoneMove.BlastPower;
        for (float t = 0; t < numPoints; t += timeBetweenPoints)
        {
            Vector3 newPoint = startingPosition + t * startingVelocity;
            newPoint.y = startingPosition.y + startingVelocity.y * t + Physics2D.gravity.y / 2f * t * t;
            points.Add(newPoint);
           
        }

        lr.SetPositions(points.ToArray());
    }
  
}