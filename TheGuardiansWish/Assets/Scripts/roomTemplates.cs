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
    private bool bossSpawned;
    public GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(waitTime <= 0 && bossSpawned == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
                bossSpawned = true;
            }
        } else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
