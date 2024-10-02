using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour {
    public GameObject[] players;

    public void Update() {
        players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length == 1) {
            Debug.Log(players[0].name + " последний выживший");
            SceneManager.LoadScene("MainMenu");
        }
    }
}