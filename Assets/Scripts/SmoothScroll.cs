using UnityEngine;

public class SmoothScroll : MonoBehaviour
{
    public RectTransform contentPanel;
    public float scrollDistance = 1080f;
    public float scrollTime = 0.5f; // Rolling time length
    public AnimationCurve scrollCurve; // Creating scroll spring effect

    private Vector2 originalPosition;
    private Vector2 targetPosition;
    private float startTime;
    private bool isScrolling = false;

    private void Start()
    {
        originalPosition = contentPanel.anchoredPosition;
        targetPosition = originalPosition;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartScrolling();
        }

        if (isScrolling)
        {
            float timeProgress = (Time.time - startTime) / scrollTime;
            float curvePosition = scrollCurve.Evaluate(timeProgress);
            contentPanel.anchoredPosition = Vector2.LerpUnclamped(originalPosition, targetPosition, curvePosition);

            if (timeProgress >= 1)
            {
                isScrolling = false;
            }
        }
    }

    private void StartScrolling()
    {
        originalPosition = contentPanel.anchoredPosition;
        targetPosition = originalPosition + new Vector2(0, scrollDistance);
        startTime = Time.time;
        isScrolling = true;
    }
}