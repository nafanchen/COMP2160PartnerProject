using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private GameObject backgroundImage;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI lastTime;
    [SerializeField] private TextMeshProUGUI bestTime;
    [SerializeField] private Button prev;
    [SerializeField] private Button next;
    [SerializeField] private Button play;
    [SerializeField] private int minLevel = 1;
    [SerializeField] private int maxLevel = 3;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private bool displayMenuDefault = false;
    public int currentLevel = 1;

    void Start()
    {
        UpdateLevelText();
        if (!displayMenuDefault)
        {
            HideMenuUI();
        }
    }

    private void UpdateLevelText()
    {
        levelText.text = "Level " + currentLevel;
        lastTime.text = "Last Time: " + scoreManager.GetLastTime(currentLevel);
        bestTime.text = "Best Time: " + scoreManager.GetBestTime(currentLevel);
    }

    public void OnPrevButtonClicked()
    {
        if (currentLevel > minLevel)
        {
            currentLevel--;
            UpdateLevelText();
        }
    }

    public void OnNextButtonClicked()
    {
        if (currentLevel < maxLevel)
        {
            currentLevel++;
            UpdateLevelText();
        }
    }

    public void OnPlayButtonClicked()
    {
        HideMenuUI();
        SceneManager.LoadScene("Level" + currentLevel);
    }

    public void HideMenuUI()
    {
        backgroundImage.SetActive(false);
        levelText.gameObject.SetActive(false);
        lastTime.gameObject.SetActive(false);
        bestTime.gameObject.SetActive(false);
        prev.gameObject.SetActive(false);
        next.gameObject.SetActive(false);
        play.gameObject.SetActive(false);
    }

    public void ShowMenuUI()
    {
        backgroundImage.SetActive(true);
        levelText.gameObject.SetActive(true);
        lastTime.gameObject.SetActive(true);
        bestTime.gameObject.SetActive(true);
        lastTime.text = "Last Time: " + scoreManager.GetLastTime(currentLevel);
        bestTime.text = "Best Time: " + scoreManager.GetBestTime(currentLevel);
        prev.gameObject.SetActive(true);
        next.gameObject.SetActive(true);
        play.gameObject.SetActive(true);
    }
}
