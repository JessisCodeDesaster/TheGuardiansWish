using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    public List<GameObject> monsterInRoomControll;
    private bool playerInRoom = false;
    private bool doorsOpen = false;
    public float dissolveTime = 4;

    public GameObject[] doors;

    public Material doorMat;
    public Material dissolveMat;
    public Material respawnMat;


    // Start is called before the first frame update
    void Start()
    {
        doors = GameObject.FindGameObjectsWithTag("Door");
        foreach (GameObject door in doors)
        {
            door.SetActive(false);
        }
        doorsOpen = true;
    }

    // Update is called once per frame
    void Update()
    {
        //close door
        if (Input.GetKeyDown(KeyCode.Q) && doorsOpen)
        {
            StartCoroutine(closeDoor());
            doorsOpen = false;
        }

        //opens door
        else if (Input.GetKeyDown(KeyCode.Q) && !doorsOpen)
        {
            StartCoroutine(openDoor());
            doorsOpen = true;
            Debug.Log("Tür geöffnet");
        }
    }

    float dissolve()
    {
        return 0.1f;
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
    }

    IEnumerator closeDoor()
    {
        foreach (GameObject door in doors)
        {
            door.SetActive(true);
            door.GetComponent<Renderer>().material = dissolveMat;
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


    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "monster")
        {
            if (playerInRoom)
            {
                Debug.Log("Door closed");
            }
        }
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
