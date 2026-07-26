using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
 public TextMeshProUGUI healthText;
    public TextMeshProUGUI halosText;
    public TextMeshProUGUI wavesText;

    public PlayerState playerState;
    public GameState gameState;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       HandleUI();
    }

    // Update is called once per frame
    void Update()
    {
       HandleUI();
    }

    void HandleUI()
    {
        healthText.text = "Lives: " + playerState.GetHealth().ToString();
        halosText.text = "Halos: " + playerState.GetHalos().ToString();
        int numWaves = gameState.GetWaves();
        if (numWaves > 0)
        {
            wavesText.text =  numWaves.ToString();
        } else
        {
            wavesText.text = "";
        }
    }
}