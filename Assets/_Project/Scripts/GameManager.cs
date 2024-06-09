using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public Image lifeFill;

    private float money;
    private float currenteLife;
    public float maxLife;
    public float Money
    {
        get { return money; }
        set { money = value; }
    }
    public float CurrenteLife
    {
        get { return currenteLife; }
        set { currenteLife = value; }
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
        money = 100;
        currenteLife = maxLife;
    }
    private void Update()
    {
        lifeFill.fillAmount = CurrenteLife / maxLife;
    }
}
