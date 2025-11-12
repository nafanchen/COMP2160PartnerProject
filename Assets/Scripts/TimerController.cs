using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private Avatar avatar;
    [SerializeField] private float countdownDuration = 3f;
    [SerializeField] private float fadeDuration = 1f;
    private float countdownTime;
    private bool countdownActive = true;
    public float levelTime = 0f;
    public bool timerRunning = false;
    private float elapsed = 0f;
    
    void Start()
    {
        countdownTime = countdownDuration;
        avatar.controls.GameMovement.Disable();
        countdownText.gameObject.SetActive(true);
    }

    void Update()
    {
        if (timerRunning)
        {
            levelTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(levelTime / 60);
            int seconds = Mathf.FloorToInt(levelTime % 60);
            int hundredths = Mathf.FloorToInt((levelTime * 100) % 100);
            timerText.text = $"{minutes:00}:{seconds:00}.{hundredths:00}";
        }
        if (countdownActive)
        {
            countdownTime -= Time.deltaTime;
            if (countdownTime > 0)
            {
                countdownText.text = Mathf.Ceil(countdownTime).ToString();
            }
            else
            {
                countdownText.text = "GO!";
                countdownActive = false;
                avatar.controls.GameMovement.Enable();
                timerRunning = true;
                StartCoroutine(FadeOutText());
            }
        }
    }

    private IEnumerator FadeOutText()
    {
        Color originalColor = countdownText.color;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            countdownText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }
        countdownText.gameObject.SetActive(false);
    }
}

