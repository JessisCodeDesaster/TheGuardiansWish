using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    public List<GameObject> monsterInRoomControll;

    public bool playerInRoom = false;
    public bool doorsOpen = false;
    public float dissolveTime = 4;

    //public List<GameObject> doors;
    public GameObject[] doors;

    public Material doorMat;
    public Material dissolveMat;
    public Material respawnMat;

    // Start is called before the first frame update
    void Start()
    {
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
