using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody body;
    public bool playerOnGround = true;
    // private Collider room;
    // private Vector3 positionRoom;

    //for the shooting
    public GameObject start;
    public List<GameObject> projectiles = new List<GameObject>();
    private GameObject projectile;
    public cameraController viewDirection;
    private float firerate;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 7.5f;
        body = GetComponent<Rigidbody>();
        projectile = projectiles[0];
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.Self);

        if (Input.GetMouseButton(0) && Time.time >= firerate)
        {
            firerate = Time.time + 1 / projectile.GetComponent<shooting>().rate;
            GameObject projectiles;
            projectiles = Instantiate(projectile, start.transform.position, Quaternion.identity);
            projectiles.transform.localRotation = viewDirection.getViewDirection();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerOnGround = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //hier die türen regeln sollte klappen!
        //Debug.Log(other);
        //room = other;
        //positionRoom = other.transform.position;
    }
}
