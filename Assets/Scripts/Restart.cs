using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //llama al reset de player para que se eliminen los efectos de powerup  y se desactiven
            Controller_Player.reset = true;
            Controller_Player._Player.gameObject.SetActive(true);
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
            Controller_Hud.gameOver = false;
            Controller_Player._Player.restart();
        }
    }
}
