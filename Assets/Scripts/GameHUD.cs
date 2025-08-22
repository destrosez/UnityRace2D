using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary> Счёт, победа/поражение, панели и смена сцены. </summary>
public class GameHUD : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private GameObject _victoryPanel;
    [SerializeField] private GameObject _losePanel;

    [Header("Gameplay")]
    [SerializeField] private float _tickSeconds = 1f;
    [SerializeField] private int _targetScore = 25;

    private int _score;
    private bool _active = true;
    private Coroutine _timer;

    // Флаги состояния доступны извне
    public static bool Lose;
    public static bool Win;

    private void Awake()
    {
        Lose = false;
        Win  = false;
        Time.timeScale = 1f; // восстановим время при старте сцены
    }

    private void Start()
    {
        _timer = StartCoroutine(Tick());
        UpdateTexts();
    }

    private void Update()
    {
        if (!_active) return;

        if (_score >= _targetScore && !Win)
        {
            Win = true;
            _active = false;
            if (_timer != null) StopCoroutine(_timer);
            if (_victoryPanel) _victoryPanel.SetActive(true);
            Time.timeScale = 0f; // стопаем сцену
        }

        if (Lose)
        {
            _active = false;
            if (_timer != null) StopCoroutine(_timer);
            if (_losePanel) _losePanel.SetActive(true);
            Time.timeScale = 0f; // стопаем сцену
            Lose = false;
        }
    }

    private IEnumerator Tick()
    {
        while (_active)
        {
            _score++;
            UpdateTexts();
            yield return new WaitForSeconds(_tickSeconds);
        }
    }

    private void UpdateTexts()
    {
        string score = _score.ToString();
        if (_timeText)  _timeText.text  = $"Road to {score}/25";
    }

    public void LoadScene(int buildIndex) => SceneManager.LoadScene(buildIndex);
}
