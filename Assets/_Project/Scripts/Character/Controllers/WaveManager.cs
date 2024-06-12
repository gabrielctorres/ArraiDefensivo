using UnityEngine;
using TMPro;
public class WaveManager : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WATTING };

    public TextMeshProUGUI Anunciador;

    public int contador;
    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    public SpawnState state = SpawnState.SPAWNING;


    void Start()
    {
        waveCountdown = timeBetweenWaves;


    }

    void Update()
    {

        if (state == SpawnState.SPAWNING)
        {
            Anunciador.text = "";
        }
        else
        {
            Anunciador.text = "";
        }
    }
}
