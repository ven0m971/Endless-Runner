using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    int score;
    public static GameManager inst;

    [SerializeField] Text scoreText;

    [SerializeField] playerController PlayerController;

   public void IncrementScore()
    {
        score++;
        scoreText.text = "SCORE: " + score;
        // Increase the player's speed
        PlayerController.speed += PlayerController.speedIncreasePerPoint;
    }

    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {

    }

    private void Update()
    {

    }
}