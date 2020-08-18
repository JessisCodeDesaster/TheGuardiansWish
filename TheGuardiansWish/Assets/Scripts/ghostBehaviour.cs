using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostBehaviour : MonoBehaviour
{
    Transform playerPosition;
    public float followRadius = 15f;
    public float movementSpeed = 0.5f;
    public int health;

    private float firerate = 2;
    public List<GameObject> enemyProjectiles = new List<GameObject>();
    private GameObject enemyProjectile;
    public GameObject start;

    public GameObject room;

    public ParticleSystem death;
    float posy;
    bool up;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        enemyProjectile = enemyProjectiles[0];
        posy = 2.5f;
        up = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewDirection = playerPosition.position - transform.position;
        float actualDistance = Vector3.Distance(playerPosition.position, transform.position);
        if(actualDistance <= followRadius)
        {
            if(posy <= 3f && up == true)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerPosition.position - transform.position), 5f * Time.deltaTime);
                transform.position += transform.forward * movementSpeed * Time.deltaTime;
                transform.position += new Vector3(0,0.003f,0);
                posy += 0.003f;
                if(posy >= 3f)
                {
                    up = false;
                }
            }
            if(posy >= 2.5f && up == false)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerPosition.position - transform.position), 5f * Time.deltaTime);
                transform.position += transform.forward * movementSpeed * Time.deltaTime;
                transform.position += new Vector3(0, -0.003f, 0);
                posy -= 0.003f;
                if (posy <= 2.5f)
                {
                    up = true;
                }
            }
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
            health--;
            if (health <= 0)
            {
                ParticleSystem ghost_despawn;
                transform.position += new Vector3(0, -5000, 0);
                ghost_despawn = Instantiate(death, transform.position + new Vector3(0, 5000, 0), Quaternion.identity);
                waitForDestroy();
                room.GetComponent<doorController>().monsterInRoomControll.Remove(gameObject);
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }
    }



    void shootAtPlayer()
    {
        GameObject enemyProjectiles;
        enemyProjectiles = Instantiate(enemyProjectile, start.transform.position, Quaternion.identity);
        enemyProjectiles.transform.localRotation = transform.rotation;
    }

    IEnumerator waitForDestroy()
    {
        yield return new WaitForSeconds(1f);
    }

    void OnDestroy()
    {
        PowerUpsController.position = transform.position + new Vector3(0,5000,0);
        PowerUpsController.monstersKilled += 1;
        Debug.Log(PowerUpsController.monstersKilled);
    }
}
