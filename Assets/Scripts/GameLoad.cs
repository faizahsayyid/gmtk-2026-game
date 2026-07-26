using UnityEngine;

public class GameLoad : MonoBehaviour
{
    public PlayerState playerState;
    public GameState gameState;
    private static GameLoad Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            playerState.ResetHealth();
            playerState.ResetHalos();
            gameState.InitGameState();
        }
    }
}