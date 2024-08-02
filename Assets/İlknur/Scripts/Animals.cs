using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals : MonoBehaviour
{
    public Transform pointA; 
    public Transform pointB;
    public float speed = 2f;

    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = pointB.position; 
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (targetPosition == pointB.position)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                targetPosition = pointA.position;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                targetPosition = pointB.position;
            }
        }
    }
}
