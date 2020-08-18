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
    private GameObject bigEnemyProjectile;

    public GameObject start1;
    public GameObject start2;
    public GameObject start3;

    public int maxHealth = 100;
    public int health;

    public Slider healthbar;

    public GameObject room;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthbar.value = health;

        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        enemyProjectile = enemyProjectiles[0];
        bigEnemyProjectile = enemyProjectiles[1];
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
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerPosition.position - transform.position), 2f * Time.deltaTime);
        if (actualDistance <= followRadius)
        {
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
        int x = Random.Range(0, 3);

        if(x == 0)
        {
            GameObject enemyProjectiles1;
            enemyProjectiles1 = Instantiate(enemyProjectile, start1.transform.position, Quaternion.identity);
            enemyProjectiles1.transform.localRotation = transform.rotation;

            GameObject enemyProjectiles2;
            enemyProjectiles2 = Instantiate(enemyProjectile, start2.transform.position, Quaternion.identity);
            enemyProjectiles2.transform.localRotation = transform.rotation;

            GameObject enemyProjectiles3;
            enemyProjectiles3 = Instantiate(enemyProjectile, start3.transform.position, Quaternion.identity);
            enemyProjectiles3.transform.localRotation = transform.rotation;
        }
        
        if (x == 1)
        {
            GameObject enemyProjectiles1;
            enemyProjectiles1 = Instantiate(enemyProjectile, start2.transform.position, Quaternion.identity);
            enemyProjectiles1.transform.localRotation = transform.rotation;
        }

        if (x == 2)
        {
            GameObject enemyProjectiles1;
            enemyProjectiles1 = Instantiate(bigEnemyProjectile, start2.transform.position, Quaternion.identity);
            enemyProjectiles1.transform.localRotation = transform.rotation;
        }

        if (x == 3)
        {
            GameObject enemyProjectiles1;
            enemyProjectiles1 = Instantiate(bigEnemyProjectile, start1.transform.position, Quaternion.identity);
            enemyProjectiles1.transform.localRotation = transform.rotation;

            GameObject enemyProjectiles2;
            enemyProjectiles2 = Instantiate(bigEnemyProjectile, start2.transform.position, Quaternion.identity);
            enemyProjectiles2.transform.localRotation = transform.rotation;

            GameObject enemyProjectiles3;
            enemyProjectiles3 = Instantiate(bigEnemyProjectile, start3.transform.position, Quaternion.identity);
            enemyProjectiles3.transform.localRotation = transform.rotation;
        }
    }
}
