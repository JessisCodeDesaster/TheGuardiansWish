using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossPortalMovement : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 0, transform.position.z), Time.deltaTime * 1f);
    }

    private void OnTriggerEnter(Collider player)
    {
        SceneManager.LoadScene("Main-blue");
    }
}
