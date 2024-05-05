﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller_Hud : MonoBehaviour
{
    public Text gameOverText;

    public static bool gameOver;

    public static int points;
    private static int pointMultiplier = 1;
    public Text pointsText;

    public Text powerUpText;

    private Controller_Player player;

    void Start()
    {
        gameOver = false;
        gameOverText.gameObject.SetActive(false);
        points = 0;
        player = GameObject.Find("Player").GetComponent<Controller_Player>();
    }

    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverText.text = "Game Over" ;
            gameOverText.gameObject.SetActive(true);
        }
        if (player!=null)
        {
            if (player.powerUpCount <= 0)
            {
                powerUpText.text = "PowerUp: None";
            }
            else if (player.powerUpCount == 1)
            {
                powerUpText.text = "PowerUp: Speed Up";
            }
            else if (player.powerUpCount == 2)
            {
                powerUpText.text = "PowerUp: Point Multiplier";
            }
            else if (player.powerUpCount == 3)
            {
                powerUpText.text = "PowerUp: Double shoot";
            }
            else if (player.powerUpCount == 4)
            {
                powerUpText.text = "PowerUp: Laser";
            }
            else if (player.powerUpCount == 5)
            {
                powerUpText.text = "PowerUp: Option";
            }
            else if (player.powerUpCount == 6)
            {
                powerUpText.text = "PowerUp: Shield";
            }
            else if (player.powerUpCount >= 7)
            {
                powerUpText.text = "PowerUp: Missile";
               
            }
        }
        pointsText.text = "Score: " + points.ToString();
    }

    public static void AddPoints(int pointsToAdd)
    {
        //a puntos se le suma la multiplicacion de los puntos que se añaden por el multiplicador, el cual cambiará cuando se use su  powup
        points += pointsToAdd * pointMultiplier;
    }
    public static void ActivatePointMultiplierPowerUp()
    {
       
        pointMultiplier = 2;
      
    }
}
