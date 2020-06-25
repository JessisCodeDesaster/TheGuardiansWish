using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomSpawn : MonoBehaviour
{
    public int openSide;
    // 1 -> brauche tür unten
    // 2 -> brauche tür oben
    // 3 -> brauche tür links
    // 4 -> brauche tür rechts

    private roomTemplates templates;
    private int random;
    private bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<roomTemplates>();
        //verzögert, da sonst buggy
        Invoke("spawnRoom", 0.1f);
    }

    // Update is called once per frame
    void spawnRoom()
    {
        if(spawned == false)
        {
            if (openSide == 1)
            {
                random = Random.Range(0, templates.bottom.Length);
                Instantiate(templates.bottom[random], transform.position, templates.bottom[random].transform.rotation);
            }
            else if (openSide == 2)
            {
                random = Random.Range(0, templates.top.Length);
                Instantiate(templates.top[random], transform.position, templates.top[random].transform.rotation);
            }
            else if (openSide == 3)
            {
                random = Random.Range(0, templates.left.Length);
                Instantiate(templates.left[random], transform.position, templates.left[random].transform.rotation);
            }
            else if (openSide == 4)
            {
                random = Random.Range(0, templates.right.Length);
                Instantiate(templates.right[random], transform.position, templates.right[random].transform.rotation);
            }
            spawned = true;
        }
    }

    //Sorgt dafür, dass nicht mehrere Räume übereinander sind
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Spawn") && other.GetComponent<roomSpawn>().spawned == true)
        {
            Destroy(gameObject);
        }
    }
}
