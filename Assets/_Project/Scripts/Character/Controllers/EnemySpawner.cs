using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WATTING };
    //public PathCreator pathCreator;

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
    [SerializeField] private int timeBetweenWaves = 5;
    [SerializeField] private float difficultyMultiplier = 0.65f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    [Header("UI")]
    [SerializeField] TextMeshProUGUI anunciador;
    [SerializeField] TextMeshProUGUI waveTxt;
    public SpawnState state = SpawnState.SPAWNING;

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesToSpawn;
    private bool isSpawning = false;
    private bool firstTime = true;
    private int countDown;

    IEnumerator StartWave()
    {
        state = SpawnState.WATTING;
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesToSpawn = EnemiesPerWave();
        state = SpawnState.SPAWNING;
        yield return null;

    }
    private int EnemiesPerWave()
    {
        return EnemyTotal = (int)(baseStartEnemies * Mathf.Pow(currentWave, difficultyMultiplier));
    }
    void SpawnEnemies()
    {
        int random = Random.Range(0, 3);
        GameObject enemyInstance;
        if(random == 0)
        {
            enemyInstance = Instantiate(enemyPrefabs[random], transform.position, Quaternion.identity);
        }
        else if (random == 1)
        {
            enemyInstance = Instantiate(enemyPrefabs[random], transform.position, Quaternion.identity);
        }
        else
        {
            enemyInstance = Instantiate(enemyPrefabs[random], transform.position, Quaternion.identity);
        }
        //enemyInstance.GetComponent<Enemie>().pathCreator = pathCreator;
        enemiesAlive++;
        enemiesToSpawn--;
    }
    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }
    void EndWave()
    {
        countDown = timeBetweenWaves;
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
        if (state == SpawnState.SPAWNING)
        {
            anunciador.text = "Eles estão vindo!!!";
        }
        else
        {
            anunciador.text = "Proxima wave virá em " + countDown + " segundos";
        }
        waveTxt.text = "Wave: " + currentWave;
    }

    
}
