using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplaySceneUI : MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private String sceneName;

    void Update()
    {
        textMeshPro.color = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b,
            (Mathf.Sin(Time.time * speed) + 1.0f) / 2.0f);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
    
}