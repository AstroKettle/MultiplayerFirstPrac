using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Camera playerPrefab1; // Префаб игрока
    public Camera playerPrefab2; // Префаб игрока
    public Camera playerPrefab3; // Префаб игрока
    public Camera playerPrefab4; // Префаб игрока

    public Button twoPlayersButton; // Кнопка для 2 игроков
    public Button threePlayersButton; // Кнопка для 3 игроков
    public Button fourPlayersButton; // Кнопка для 4 игроков

    private void Start()
    {
        twoPlayersButton.onClick.AddListener(() => StartGame(2));
        threePlayersButton.onClick.AddListener(() => StartGame(3));
        fourPlayersButton.onClick.AddListener(() => StartGame(4));
        DontDestroyOnLoad(GameObject.Find("Ground"));
    }

    private void StartGame(int playerCount)
    {
        // Разделяем экран в зависимости от количества игроков
        SetupScreen(playerCount);
        
        // Спавним игроков
        SceneManager.LoadScene("SampleScene");
    }

    private void SetupScreen(int playerCount)
    {
        switch (playerCount)
        {
            case 2:
                // Настройка экрана для 2 игроков
                playerPrefab1.rect = new Rect(-0.5f, 0, 1, 1);
                playerPrefab2.rect = new Rect(0.5f, 0, 1, 1);
                DontDestroyOnLoad(GameObject.Find("Player1"));
                DontDestroyOnLoad(GameObject.Find("Player2"));
                break;
            case 3:
                playerPrefab1.rect = new Rect(0, 0, 0.33f, 1);
                playerPrefab2.rect = new Rect(0.33f, 0, 0.33f, 1);
                playerPrefab3.rect = new Rect(0.66f, 0, 0.33f, 1);
                DontDestroyOnLoad(GameObject.Find("Player1"));
                DontDestroyOnLoad(GameObject.Find("Player2"));
                DontDestroyOnLoad(GameObject.Find("Player3"));
                break;
            case 4:
                playerPrefab1.rect = new Rect(-0.5f, 0.5f, 1, 1);
                playerPrefab2.rect = new Rect(0.5f, 0.5f, 1, 1);
                playerPrefab3.rect = new Rect(-0.5f, -0.5f, 1, 1);
                playerPrefab4.rect = new Rect(0.5f, -0.5f, 1, 1);
                DontDestroyOnLoad(GameObject.Find("Player1"));
                DontDestroyOnLoad(GameObject.Find("Player2"));
                DontDestroyOnLoad(GameObject.Find("Player3"));
                DontDestroyOnLoad(GameObject.Find("Player4"));
                break;
        }
    }

    // private void SpawnPlayers(int playerCount)
    // {
        
    //     ;
    //     Instantiate(playerPrefab1, GetSpawnPosition(1, playerCount), Quaternion.identity);
    //     Instantiate(playerPrefab2, spawnPosition, Quaternion.identity);
    //     Instantiate(playerPrefab3, spawnPosition, Quaternion.identity);
    //     Instantiate(playerPrefab4, spawnPosition, Quaternion.identity);
        
    // }

    // private Vector3 GetSpawnPosition(int index, int playerCount)
    // {
    //     float offsetX = (index % 2) * 2 - 1; // -1 или 1 для X
    //     float offsetY = (index / 2) * 2 - 1; // -1 или 1 для Y

    //     return new Vector3(offsetX * 5f, offsetY * 5f, 0); // Измените значения для настройки расстояния между игроками
    // }
}

