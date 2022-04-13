using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool gameEnded = false;

    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        gameEnded = false;
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

        void EndGame()
        {
            gameEnded = true;
            gameOverUI.SetActive(true);
            Debug.Log("Game over");

        }
    }
}
