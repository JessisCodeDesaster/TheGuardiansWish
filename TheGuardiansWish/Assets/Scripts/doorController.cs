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
    public Material dissolveMatFlower;
    public Material respawnMat;

    public List<GameObject> flowers;
    public Material flower_light;
    public Material flower_dark;

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
            //StartCoroutine(colorFlower());
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

    /*
    IEnumerator colorFlower()
    {
        for (int k = 0; k < flowers.Count; k++)
        {
            flowers[k].GetComponent<Renderer>().material = dissolveMatFlower;
        }
        for (float i = 0.51f; i > -1.1f; i -= 0.1f)
        {
            yield return new WaitForSeconds(0.04f);
            dissolveMat.SetFloat("StartTime", i);
        }
        for (int k = 0; k < flowers.Count; k++)
        {
            flowers[k].GetComponent<Renderer>().material = flower_light;
        }
    }*/

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
