using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING };
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

    public ParticleSystem spawnParticule;
    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    [Header("UI")]
    [SerializeField] TextMeshProUGUI anunciador;
    [SerializeField] TextMeshProUGUI waveTxt;
    [SerializeField] TextMeshProUGUI wavePauseTxt;
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
        state = SpawnState.WAITING;
        countDown = timeBetweenWaves;


        StartCoroutine(Countdown());


        yield return new WaitForSeconds(timeBetweenWaves);

        isSpawning = true;
        enemiesToSpawn = EnemiesPerWave();
        state = SpawnState.SPAWNING;
        yield return null;
    }

    private IEnumerator Countdown()
    {
        while (countDown > 0)
        {
            if (anunciador != null)
            {
                if (firstTime) anunciador.text = "O Jogo vai começar em " + countDown + " segundos";
                else anunciador.text = "Próxima wave virá em " + countDown + " segundos";
            }

            yield return new WaitForSeconds(1f);
            countDown--;
        }
    }

    private int EnemiesPerWave()
    {
        return EnemyTotal = (int)(baseStartEnemies * Mathf.Pow(currentWave, difficultyMultiplier));
    }

    void SpawnEnemies()
    {
        int random = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyInstance = Instantiate(enemyPrefabs[random], transform.position, Quaternion.identity);
        spawnParticule.Play();
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
        GameManager.instance.Money += 50;
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
        StartCoroutine(StartWave());

    }

    // Update is called once per frame
    void Update()
    {
        if (startWave)
        {
            if (!isSpawning) return;
            timeSinceLastSpawn += Time.deltaTime;
            if (timeSinceLastSpawn >= (1 / enemiesPerSecond) && enemiesToSpawn > 0)
            {
                //Spawnar inimigo
                SpawnEnemies();
                timeSinceLastSpawn = 0;
            }

            if (enemiesToSpawn == 0 && enemiesAlive == 0)
            {
                EndWave();
            }
        }
        if (state == SpawnState.SPAWNING)
        {
            if (anunciador != null)
                anunciador.text = "Eles estão vindo!!!";
        }
        else
        {
            if (anunciador != null && countDown > 0)
                anunciador.text = "Próxima wave virá em " + countDown + " segundos";
        }
        if (waveTxt != null) waveTxt.text = "Wave: " + currentWave;
        if (wavePauseTxt != null) wavePauseTxt.text = "SOBREVIVEU POR " + currentWave + " WAVES";
    }
}
