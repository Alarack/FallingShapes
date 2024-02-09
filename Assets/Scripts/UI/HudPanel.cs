using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudPanel : Singleton<HudPanel> {

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public float duration;

    private Timer timer;
    private float score;

    public GameObject gameOverScreen;


    private void Start() {
        BeginTimer();
    }

    public void BeginTimer() {
        timer = new Timer(duration, OnTimeOut, false);
    }

    private void StopTimer() {
        timer = null;
    }


    private void Update() {
        if (timer != null) {
            timer.UpdateClock();
            UpdateTime();
        }
    }

    private void UpdateTime() {
        if (timer == null)
            return;

        int timeRemaining = Mathf.RoundToInt(timer.Duration - timer.TimeElapsed);
        timeText.text = timeRemaining.ToString();
    }

    public static void UpdateScoreText(float points) {
        Instance.score += points;
        Instance.scoreText.text = "Score: " + Instance.score.ToString();
    }

    public void ResetScore() {
        score = 0;
        UpdateScoreText(0);
    }

    private void OnTimeOut() {
        StopTimer();
        ObjectSpawner.StopSpawning();
        gameOverScreen.SetActive(true);

    }


    public void OnRestartClicked() {
        ResetScore();
        BeginTimer();
        ObjectSpawner.BeginSpawning();
        gameOverScreen.SetActive(false);
    }

}
