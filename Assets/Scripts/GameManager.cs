using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;

    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Economy.Lives <= 0)
        {
            EndGame();
        }
        if (gameEnded)
            return;

        /*if (Tower.targetWaypointIndex)
        {
            EndGame();
        }
    }*/

        void EndGame()
        {
            gameEnded = true;
            gameOverUI.SetActive(true);
            Debug.Log("Game over");

        }
    }
}
