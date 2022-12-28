using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public float hp = 100;
    public Slider hpSliderUi;
    [SerializeField] private TextMeshProUGUI scoreTextMeshPro;

    private void Start()
    {
        ScoreManager.GetInstance().Reinit();
    }

    void FixedUpdate()
    {
        if(hp <= 0)
        {
            SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
        }
        
        scoreTextMeshPro.SetText("Score : "+ScoreManager.GetInstance().Score);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("asteroid"))
        {
            GameObject asteroidGo = other.gameObject;
            Destroy(asteroidGo);
            hp -= 10;
            hpSliderUi.value = Mathf.Max(hp, 0);
        }
    }
}
