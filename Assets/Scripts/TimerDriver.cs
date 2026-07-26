using UnityEngine;

public class TimerDriver : MonoBehaviour
{
    public GameState gameState;

    void Update()
    {
        gameState.UpdateTimer(Time.deltaTime);
    }
}