using UnityEngine;

public class TimerBar : MonoBehaviour
{
    public RectTransform bar;

    public GameState gameState;

    public float width;

    // Update is called once per frame
    void Update()
    {
        bar.sizeDelta = new Vector2(width * gameState.GetTimerPercentage(), bar.sizeDelta.y);
    }
}