using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{

    private AudioSource audioSource;
    private TextMeshProUGUI scoreText;
    private int score;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        scoreText = GameObject.Find("Coin Text").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        score = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == MyTags.COIN_TAG)
        {
            collision.gameObject.SetActive(false);
            audioSource.Play();
            score++;
            scoreText.text = "x" + score;
        }
    }





























}// CLASS
