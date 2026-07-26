using UnityEngine;
using System;

[CreateAssetMenu(fileName = "GameState", menuName = "Scriptable Objects/GameState")]
public class GameState : ScriptableObject
{
    public Action<int> OnWave;
    public float waveDuration = 10f; // Duration of the timer in seconds
    public float coolDownDuration = 30f; // Duration of the timer in seconds

    public int minWaves = 3;
    public int maxWaves = 10;

    private int stage = 0; // stage 0 - easy, stage 1 - medium, stage 2> - hard


    private int wavesRemaining = 0;
    private int totalWaves = 0;
    private bool isCoolDown = true;
    private float timeRemaining = 0f;

    private int secondsOnLastTick;


    public void InitGameState()
    {
        isCoolDown = true;
        timeRemaining = coolDownDuration;
        wavesRemaining = 0;
        totalWaves = 0;
        stage = 0;
    }

    public void SetWaves(int numWaves)
    {
        wavesRemaining = numWaves;
        totalWaves = numWaves;
    }

    public int GetWaves()
    {
        return wavesRemaining;
    }

    public bool GetIsCoolDown() {
        return isCoolDown;
    }

    public int GetStage()
    {
        return stage;
    }

    public void ResetTimer()
    {
        timeRemaining = isCoolDown ? coolDownDuration : waveDuration;
    }

    public void UpdateTimer(float deltaTime)
    {

        timeRemaining -= deltaTime;
        if (timeRemaining <= 0f)
        {
            HandleTimerComplete();
            ResetTimer();
        }
    }

    public float GetTimerPercentage()
    {
        float duration = isCoolDown ? coolDownDuration : waveDuration;
        if (duration <= 0f)
        {
            return 0f;
        }

        return Mathf.Clamp01(timeRemaining / duration);
    }

    private void HandleTimerComplete()
    {
        if (isCoolDown)
        {
            // Cooldown finished. Start the next wave group.
            if (stage == 0)
            {
                totalWaves = minWaves;
            }
            else if (stage == 1)
            {
                totalWaves = minWaves + 2;
            }
            else
            {
                totalWaves = (int)Mathf.Floor(UnityEngine.Random.Range(minWaves, maxWaves));
            }

            wavesRemaining = totalWaves;
            isCoolDown = false;
            OnWave?.Invoke(totalWaves - wavesRemaining);
            return;
        }

        if (wavesRemaining == 0)
        {
            stage += 1;
            isCoolDown = true;
            return;
        }

        wavesRemaining -= 1;
        OnWave?.Invoke(totalWaves - wavesRemaining);
    }
}
