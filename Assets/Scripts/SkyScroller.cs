using UnityEngine;

public class SkyScroller : MonoBehaviour
{
    public RectTransform sky1;
    public RectTransform sky2;

    public float speed = 100f; // pixels per second
    public float overlap = 1f;


    private float height;

    void Start()
    {
        height = sky1.rect.height * sky1.localScale.y;
        sky1.anchoredPosition = Vector2.zero;
        sky2.anchoredPosition = new Vector2(0, height);
    }

    void Update()
    {
        // Move both images downward
        sky1.anchoredPosition += Vector2.down * speed * Time.deltaTime;
        sky2.anchoredPosition += Vector2.down * speed * Time.deltaTime;

        // When one image is completely below the other, move it back to the top
        if (sky1.anchoredPosition.y <= -height + overlap)
        {
            sky1.anchoredPosition = new Vector2(
                sky1.anchoredPosition.x,
                sky2.anchoredPosition.y + height);
        }

        if (sky2.anchoredPosition.y <= -height + overlap)
        {
            sky2.anchoredPosition = new Vector2(
                sky2.anchoredPosition.x,
                sky1.anchoredPosition.y + height);
        }
    }
}