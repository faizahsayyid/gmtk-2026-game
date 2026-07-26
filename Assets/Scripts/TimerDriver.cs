using UnityEngine;

public class TimerDriver : MonoBehaviour
{
    public GameState gameState;
    public PlayerState playState;

    void Update()
    {
        int health = playState.GetHealth();
        if (health <=0) return;
        gameState.UpdateTimer(Time.deltaTime);
    }
}