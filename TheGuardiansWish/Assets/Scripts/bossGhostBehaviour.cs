using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossGhostBehaviour : MonoBehaviour
{
    Transform playerPosition;
    public float followRadius = 15f;
    public float movementSpeed = 0.5f;

    private float firerate = 2;
    public List<GameObject> enemyProjectiles = new List<GameObject>();
    private GameObject enemyProjectile;
    public GameObject start;


    public int maxHealth = 100;
    public int health;

    public Slider healthbar;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthbar.value = health;

        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        enemyProjectile = enemyProjectiles[0];
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.value = health;

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        Vector3 viewDirection = playerPosition.position - transform.position;
        float actualDistance = Vector3.Distance(playerPosition.position, transform.position);
        if (actualDistance <= followRadius)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerPosition.position - transform.position), 2f * Time.deltaTime);
            transform.position += transform.forward * movementSpeed * Time.deltaTime;

            if (Time.time >= firerate)
            {
                firerate = Time.time + 1 / enemyProjectile.GetComponent<shooting>().rate;
                shootAtPlayer();
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            health = health -10;
            Destroy(other.gameObject);
        }
    }

    void shootAtPlayer()
    {
        GameObject enemyProjectiles;
        enemyProjectiles = Instantiate(enemyProjectile, start.transform.position, Quaternion.identity);
        enemyProjectiles.transform.localRotation = transform.rotation;
    }
}
