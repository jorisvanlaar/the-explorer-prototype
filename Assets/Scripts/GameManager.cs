using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject crystal;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float enemyInterval;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject hud;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject titleScreen;
    [SerializeField] public GameObject gameOverScreen;
    [SerializeField] private GameObject mobileControls;
    private float spawnRange = 6;
    private int crystalCount;
    private int score;
    public bool isGameActive;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        crystalCount = GameObject.FindGameObjectsWithTag("Crystal").Length;
        if (crystalCount == 0 && isGameActive)
        {
            SpawnCrystal();
        }

        if (!isGameActive)
        {
            CancelInvoke();
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        return new Vector3(spawnPosX, 0, spawnPosZ);
    }

    private void SpawnCrystal()
    {
        Instantiate(crystal, GenerateSpawnPosition(), crystal.transform.rotation);
    }

    private void SpawnEnemy()
    {
        Instantiate(enemy, GenerateSpawnPosition(), enemy.transform.rotation);
    }

    public void UpdateScore()
    {
        score += 1;
        scoreText.text = $"{ score }";
    }

    public void StartGame()
    {
        isGameActive = true;
        score = 0;
        hud.gameObject.SetActive(true);
        player.gameObject.SetActive(true);
        mobileControls.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
        SpawnCrystal();
        InvokeRepeating("SpawnEnemy", 1, enemyInterval);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
