using UnityEngine.UI;
using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayManager : MonoBehaviour {
    public GameObject[] players;
    public GameObject winPanel;
    public TMP_Text winner;


    public void Start() {
        winPanel.SetActive(false);
    }

    public void Update() {
        players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length == 1) {
            Debug.Log(players[0].name + " последний выживший");
            winPanel.SetActive(true);
            winner.text = players[0].name + " is WIN";
            
            StartCoroutine(LoadNextSceneAfterTime(5));
        }
    }

    IEnumerator LoadNextSceneAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        // Загрузить следующую сцену
        Destroy(players[0].gameObject);
        SceneManager.LoadScene("MainMenu");
    }
}