using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [Header("Controle")]
    //Controle
    public bool startWave = false;

    [Header("Variáveis")]
    //Variaveis
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float baseStartEnemies = 5;
    [SerializeField] private int EnemyTotal = 0;
    //Em segundos
    [SerializeField] private float enemiesPerSecond = 4;
    [SerializeField] private float timeBetweenWaves = 5;
    [SerializeField] private float difficultyMultiplier = 0.65f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesToSpawn;
    private bool isSpawning = false;
    private bool firstTime = true;

    IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesToSpawn = EnemiesPerWave();
        
    }
    private int EnemiesPerWave()
    {
        return EnemyTotal = (int)(baseStartEnemies * Mathf.Pow(currentWave, difficultyMultiplier));
    }
    void SpawnEnemies()
    {
        if(Random.Range(0,2)%2 == 0)
        {
            Instantiate(enemyPrefabs[0], transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(enemyPrefabs[1], transform.position, Quaternion.identity);
        }
        enemiesAlive++;
        enemiesToSpawn--;
    }
    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }
    void EndWave()
    {
        firstTime = false;
        isSpawning = false;
        timeSinceLastSpawn = 0;
        currentWave++;
        StartCoroutine(StartWave());
    }
    private void OnEnable()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }
    private void OnDisable()
    {
        onEnemyDestroy.RemoveListener(EnemyDestroyed);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (firstTime)
        {
            isSpawning = true;
            enemiesToSpawn = EnemiesPerWave();
        }
        else
        {
            StartCoroutine(StartWave());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(startWave)
        {
            if (!isSpawning) return;
            timeSinceLastSpawn += Time.deltaTime;
            if (timeSinceLastSpawn >= (1/ enemiesPerSecond) && enemiesToSpawn > 0)
            {
                //Spawnar inimigo
                SpawnEnemies();
                timeSinceLastSpawn = 0;
            }

            if(enemiesToSpawn == 0 && enemiesAlive == 0)
            {
                EndWave();
            }
        }
    }

    
}
