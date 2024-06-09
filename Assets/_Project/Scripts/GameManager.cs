using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // A única instância do GameManager
    public static GameManager instance;

    // Propriedade pública para acessar a instância

    private float money;

    public float Money
    {
        get { return money; }
        set { money = value; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        money = 0;
    }
    private void Update()
    {

    }
}
