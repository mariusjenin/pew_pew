using System;
using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTextMeshPro;

    private void Start()
    {
        scoreTextMeshPro.SetText("Score : "+ScoreManager.GetInstance().Score);
    }
}