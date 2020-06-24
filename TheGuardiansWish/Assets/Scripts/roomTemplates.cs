using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomTemplates : MonoBehaviour
{
    public GameObject[] top;
    public GameObject[] bottom;
    public GameObject[] left;
    public GameObject[] right;

    public List<GameObject> rooms;

    public float waitTime;
    public GameObject boss;
    public GameObject  monster;

    public int rand;
    public int x;
    public int z;
    public Vector3 position;

    public bool spawned;
    int roomCount;

    // Start is called before the first frame update
    void Start()
    {
        spawned = false;
        waitTime = 1;
        roomCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(waitTime <= 0 && spawned == false)
        {
            spawnEnemies();
        } else
        {
            waitTime -= Time.deltaTime;
        }
    }

    void spawnEnemies()
    {
        for (int i = 0; i < rooms.Count-1; i++)
        {
            rand = Random.Range(1, 5);
            roomCount++;
            for (int j = 0; j < rand; j++)
            {
                x = Random.Range(-9, 9);
                z = Random.Range(-9, 9);
                position = new Vector3(x, 1.5f, z);
                Instantiate(monster, rooms[i].transform.position + position, Quaternion.identity);
            }
        }
        if (roomCount+1 == rooms.Count)
        {
            position = new Vector3(0, 1.5f, 0);
            Instantiate(boss, rooms[roomCount].transform.position + position, Quaternion.identity);
        }
        spawned = true;
    }
}
