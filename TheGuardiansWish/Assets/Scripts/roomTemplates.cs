﻿
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
    public List<GameObject> monsterInRoom = new List<GameObject>();

    public float waitTime;
    public GameObject boss;
    public GameObject monster;
    public GameObject trap;

    public int rand;
    public int x;
    public int z;
    public Vector3 position;

    public bool spawned;
    int roomCount;

    int monstercount;

    // Start is called before the first frame update
    void Start()
    {
        spawned = false;
        waitTime = 1.5f;
        roomCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime <= 0 && spawned == false)
        {
            spawnEnemies();
        } 
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    void spawnEnemies()
    {
        for (int i = 0; i < rooms.Count - 1; i++)
        {
            rand = Random.Range(2, 5);
            roomCount++;
            for (int j = 0; j < rand; j++)
            {
                x = Random.Range(-9, 9);
                z = Random.Range(-9, 9);
                position = new Vector3(x, 1.5f, z);
                rooms[i].GetComponent<doorController>().monsterInRoomControll.Add(Instantiate(monster, rooms[i].transform.position + position, Quaternion.identity));
                int count = rooms[i].GetComponent<doorController>().monsterInRoomControll.Count;
                rooms[i].GetComponent<doorController>().monsterInRoomControll[count -1].GetComponent<ghostBehaviour>().room = rooms[i];
            }
        Debug.Log(roomCount);
            
        }
        if (roomCount +1 == rooms.Count)
        {
            position = new Vector3(4, 1, 0);
            rooms[roomCount].GetComponent<doorController>().monsterInRoomControll.Add(Instantiate(boss, rooms[roomCount].transform.position + position, Quaternion.identity));
            int count2 = rooms[roomCount].GetComponent<doorController>().monsterInRoomControll.Count;
            rooms[roomCount].GetComponent<doorController>().monsterInRoomControll[count2 - 1].GetComponent<bossGhostBehaviour>().room = rooms[roomCount];

            Debug.Log("Boss");
        }
        spawned = true;

    }
}