using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    public List<GameObject> monsterInRoomControll;
    public bool bossDead;

    public bool playerInRoom = false;
    public bool doorsOpen = false;

    public GameObject[] doors;

    public Material doorMat;
    public Material dissolveMat;
    public Material dissolveMatFlower;
    public Material respawnMat;

    public List<GameObject> flowers;
    public Material flower_light;
    public Material flower_dark;

    // Start is called before the first frame update
    void Start()
    {
        bossDead = false; 
        foreach (GameObject door in doors)
        {
            door.SetActive(false);
        }
        doorsOpen = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRoom && monsterInRoomControll.Count != 0 && doorsOpen)
        {
            doorsOpen = false;
            StartCoroutine(closeDoor());
        }

        else if (playerInRoom && monsterInRoomControll.Count == 0 && !doorsOpen )
        {
            doorsOpen = true;
            StartCoroutine(openDoor());

            foreach (GameObject flower in flowers)
            {
                StartCoroutine(colorFlower(flower));
            }
        }
    }

    IEnumerator openDoor()
    {
        foreach (GameObject door in doors)
        {
            door.GetComponent<Renderer>().material = dissolveMat;
        }
        for (float i = -1.1f; i < 0.51f; i += 0.1f)
        {
            yield return new WaitForSeconds(0.04f);
            dissolveMat.SetFloat("StartTime", i);
        }
        foreach (GameObject door in doors)
        {
            door.SetActive(false);
        }
        Debug.Log("Tür geöffnet");
    }
    
    IEnumerator colorFlower(GameObject flower)
    {
        yield return new WaitForSeconds(0.5f);
        int r = Random.Range(0, 2);
        if (r == 0)
        {
            flower.GetComponent<Renderer>().material = flower_light;
        }
        else if (r == 1)
        {
            flower.GetComponent<Renderer>().material = flower_dark;
        }
    }

    IEnumerator closeDoor()
    {
        foreach (GameObject door in doors)
        {
            door.SetActive(true);
            door.GetComponent<Renderer>().material = dissolveMat;
            Debug.Log("1x Tür zu");
        }
        for (float i = 0.51f; i > -1.1f; i -= 0.1f)
        {
            yield return new WaitForSeconds(0.04f);
            dissolveMat.SetFloat("StartTime", i);
        }
        foreach (GameObject door in doors)
        {
            door.GetComponent<Renderer>().material = doorMat;
        }
        Debug.Log("Tür geschlossen");
    }


    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRoom = false;
            Debug.Log("Player left");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRoom = true;
            Debug.Log("Player entered");
        }
    }
}
