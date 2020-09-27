using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bluePortal : MonoBehaviour
{
    private void OnTriggerEnter(Collider player)
    {
        SceneManager.LoadScene("Dungeon");
    }
}
