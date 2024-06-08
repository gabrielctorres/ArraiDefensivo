using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    //Variaveis
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float baseEnemies = 5;
    //Em segundos
    [SerializeField] private float spawnRate = 1;
    [SerializeField] private float timeBetweenWaves = 5;
    [SerializeField] private float difficultyMultiplier = 0.65f;

    public bool startWave = false;

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesToSpawn;
    private bool isSpawning = false;


    void initialWave()
    {

    }

    void StartWave()
    {
        isSpawning = true;
        enemiesToSpawn = EnemiesPerWave();
    }

    public void SpawnEnemies()
    {

    }

    private int EnemiesPerWave()
    {
        return (int)(baseEnemies * Mathf.Pow(currentWave, difficultyMultiplier));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startWave)
        {
            timeSinceLastSpawn += Time.deltaTime;
            if (timeSinceLastSpawn >= (1/spawnRate))
            {

            }
        }
    }
}
