using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterController : MonoBehaviour
{
    public static float moveSpeed;
    public Rigidbody body;
    public bool playerOnGround = true;

    //for the lifebar
    public int health;
    public RawImage[] hearts_full;
    public RawImage[] hearts_empty;

    //for the shooting
    public GameObject start;
    public List<GameObject> projectiles = new List<GameObject>();
    private GameObject projectile;
    public cameraController viewDirection;
    public static float firerate;

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
        for (int i = 0; i<8; i++)
        {
            if (i < health)
            {
                hearts_full[i].enabled = true;
                hearts_empty[i].enabled = false;
            }
            else
            {
                hearts_full[i].enabled = false;
                hearts_empty[i].enabled = true;
            }
            if (health <= 0)
            {
                FindObjectOfType<GameManager>().GameOver();
            }
        }

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemyProjectile")
        {
            Destroy(other.gameObject);
            health--;
        }
    }

}
