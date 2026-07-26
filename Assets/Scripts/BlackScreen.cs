using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayerState playerState;
    public Image blackScreenImage;

    public float blackScreenDelay = 1f;
    void OnEnable()
    {
        playerState.OnShowBlackScreen += HandleShowBlackScreen;
    }

    void OnDisable()
    {
        playerState.OnShowBlackScreen -= HandleShowBlackScreen;
    }

    void HandleShowBlackScreen()
    { 
        StartCoroutine(ShowBlackScreen());
    }

    private IEnumerator ShowBlackScreen()
    {
        blackScreenImage.color = new Color(0, 0, 0, 1); // Set black screen to fully opaque
        yield return new WaitForSeconds(blackScreenDelay);
        playerState.ResetHealth();
        playerState.ResetHalos();
        SceneManager.LoadScene("Home", LoadSceneMode.Single);
        blackScreenImage.color = new Color(0, 0, 0, 0);
    }
}