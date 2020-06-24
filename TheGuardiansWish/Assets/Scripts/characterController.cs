using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody body;
    public bool playerOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 7.5f;
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.Self);

        if (Input.GetButtonDown("Jump") && playerOnGround == true)
        {
            body.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            playerOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerOnGround = true;
        }
    }
}
