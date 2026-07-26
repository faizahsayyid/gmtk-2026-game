using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
 public TextMeshProUGUI healthText;
    public TextMeshProUGUI halosText;
    public TextMeshProUGUI wavesText;
    public TextMeshProUGUI stageText;
    public TextMeshProUGUI lostSoulsText;

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
        if (healthText != null)
        {
            healthText.text = "Lives: " + playerState.GetHealth().ToString();
        }

        if (halosText != null)
        {
            halosText.text = "Halos: " + playerState.GetHalos().ToString();
        }

        if (wavesText != null)
        {
            int numWaves = gameState.GetWaves();
            if (numWaves > 0)
            {
                wavesText.text =  numWaves.ToString();
            }
            else
            {
                wavesText.text = "";
            }
        }

        if (stageText != null)
        {
            stageText.text = "Stage: " + gameState.GetStage().ToString();
        }

        if (lostSoulsText != null)
        {
            lostSoulsText.text = "Lost Souls: " + playerState.GetLostSouls().ToString();
        }
    }
}