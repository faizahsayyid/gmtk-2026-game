using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{

    public Button startButton;
    public PlayerState playerState;
    public GameState gameState;

    void Start()
    {
        startButton.onClick.AddListener(OnStartGame);
    }

    void OnStartGame()
    {
        playerState.ResetHealth();
        playerState.ResetHalos();
        playerState.ResetLostSouls();
        gameState.InitGameState();
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}