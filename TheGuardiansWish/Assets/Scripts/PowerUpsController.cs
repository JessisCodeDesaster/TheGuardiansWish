using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsController : MonoBehaviour
{
    public static int monstersKilled;
    public int killsRequired = 5;
    public List<GameObject> PowerUps = new List<GameObject>();
    public static Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(killsRequired == monstersKilled)
        {
            spawnPowerUp();
            createKillsRequired();
        }
    }

    void createKillsRequired()
    {
        killsRequired = monstersKilled + Random.Range(5, 20);
    }

    void spawnPowerUp()
    {
        float posx = position.x;
        float posz = position.z;
        Vector3 newPos = new Vector3(posx, 1.5f, posz);
        PowerUps.Add(Instantiate(PowerUps[Random.Range(0, 2)], newPos, Quaternion.identity));
    }
}
