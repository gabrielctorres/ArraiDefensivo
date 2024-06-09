using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject button;
    [SerializeField] private TMPro.TextMeshProUGUI coinsText;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        coinsText.text = "$: 0";
    }

    public void ButtonExitShop()
    {
        menu.SetActive(false);
        button.SetActive(true);
    }
    public void ButtonEnterShop()
    {
        menu.SetActive(true);
        button.SetActive(false);
    }
    public void UpdateCoins(int coins)
    {
        coinsText.text = "$: "+coins.ToString();
    }


}
