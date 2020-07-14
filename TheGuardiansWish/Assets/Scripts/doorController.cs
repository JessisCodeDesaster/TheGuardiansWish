using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    public List<GameObject> monsterInRoomControll;

    public  bool playerInRoom = false;
    private bool doorsOpen = false;
    public float dissolveTime = 4;

    //public List<GameObject> doors;
    public GameObject[] doors;

    public Material doorMat;
    public Material dissolveMat;
    public Material respawnMat;

    public int monstercount;
    public int monsterkilled;

    // Start is called before the first frame update
    void Start()
    {
        doors = GameObject.FindGameObjectsWithTag("Door");
        foreach (GameObject door in doors)
        {
            door.SetActive(false);
        }
        doorsOpen = true;

        monstercount = 0;
        monsterkilled = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //close door
        if (Input.GetKeyDown(KeyCode.Q) && doorsOpen)
        {
            doorsOpen = false;
            StartCoroutine(closeDoor());
            Debug.Log("Tür geschlossen");
        }

        //opens door
        else if (Input.GetKeyDown(KeyCode.Q) && !doorsOpen)
        {
            doorsOpen = true;
            StartCoroutine(openDoor());
            Debug.Log("Tür geöffnet");
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

    /*public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "monster")
        {
            if (playerInRoom)
            {
                Debug.Log("Door closed");
            }
        }
    }*/

    /*public void OnTriggerExit(Collider other)
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
    }*/

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "monster")
        {
            monsterInRoomControll.Add(other.gameObject);
            this.monstercount++;
            Debug.Log("Monster entered");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "monster")
        {
            this.monsterkilled++;
            Debug.Log("Monster left");
        }
    }
}
