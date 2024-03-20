using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject block;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;

    public GameObject tapText;
    public TextMeshProUGUI scoreText;
    int score = 0;



    bool gameStarted = false;

    void Start() {
        scoreText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            StartSpawing();
            gameStarted = true;
            scoreText.enabled = true;
            tapText.SetActive(false);
        }
    }

    private void StartSpawing()
    {
        InvokeRepeating("SpawnBlock", 0.7f, spawnRate);
    }

    private void SpawnBlock()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(block, spawnPos, Quaternion.identity);

        score++;
        scoreText.text = score.ToString();

    }
}
