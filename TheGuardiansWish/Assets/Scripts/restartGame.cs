using UnityEngine;
using UnityEngine.SceneManagement;

public class restartGame : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            Restart();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("Dungeon");
    }
}
