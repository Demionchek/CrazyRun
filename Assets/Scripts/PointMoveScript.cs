using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMoveScript : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private float speed;
    private int currPoint;
    
    private void Start()
    {
        currPoint = 0;
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,points[currPoint].position,step);

        if (Vector3.Distance(transform.position, points[currPoint].position) < 0.3f)
        {
            currPoint++;
            if (currPoint >= points.Length)
            {
                currPoint = 0;
            }
        }
    }
}
