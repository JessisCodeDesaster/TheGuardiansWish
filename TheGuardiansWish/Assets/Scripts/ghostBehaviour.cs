using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostBehaviour : MonoBehaviour
{
    Transform playerPosition;
    public float followRadius = 15f;
    public float movementSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewDirection = playerPosition.position - transform.position;
        float actualDistance = Vector3.Distance(playerPosition.position, transform.position);
        if(actualDistance <= followRadius)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerPosition.position - transform.position), 2f * Time.deltaTime);
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }
    }
}
