using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private Bird _bird;

    public void OnEnable()
    {
        _bird.OnScoreChanged += OnScoreChanged;
    }

    public void OnDisable()
    {
        _bird.OnScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _scoreText.text = score.ToString();
    }
}


