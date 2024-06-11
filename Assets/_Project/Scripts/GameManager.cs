using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public Image lifeFill;

    public TextMeshProUGUI lifeTxt;
    public TextMeshProUGUI velocityTxt;
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
        money = 200;
        currenteLife = maxLife;
    }
    private void Update()
    {
        lifeFill.fillAmount = CurrenteLife / maxLife;
        lifeTxt.text = CurrenteLife.ToString() + " / " + maxLife.ToString();
        velocityTxt.text = Time.timeScale.ToString() + "x";
    }
    public void UpdateVelocity()
    {
        if (Time.timeScale == 1)
            Time.timeScale = 2;
        else if (Time.timeScale == 2)
            Time.timeScale = 1;
    }
}
