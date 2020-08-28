using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("game over");
            gameOver();
        }
    }

    void gameOver()
    {
        SceneManager.LoadScene("DeathScreen");
    }
}
