using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public Image lifeFill;

    public TextMeshProUGUI lifeTxt;
    public TextMeshProUGUI velocityTxt;
    private float money;
    private float currenteLife;
    public float maxLife;

    public GameObject MenuPause;
    public GameObject MenuGame;
    public GameObject fireParticule;

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
            //DontDestroyOnLoad(gameObject);
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

        if (currenteLife <= 0)
        {
            MenuGame.SetActive(false);
            MenuPause.SetActive(true);
            fireParticule.SetActive(false);
        }
    }
    public void ResetScene()
    {
        SceneManager.LoadScene("CenaJogo");
    }
    public void UpdateVelocity()
    {
        if (Time.timeScale == 1)
            Time.timeScale = 2;
        else if (Time.timeScale == 2)
            Time.timeScale = 1;
    }
}
