using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject button;
    [SerializeField] private TMPro.TextMeshProUGUI coinsText;

    [SerializeField] private List<GameObject> towers = new List<GameObject>();

    [SerializeField] private DragDrop dragDrop;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        coinsText.text = "$: " + GameManager.instance.Money.ToString();

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
    private void Update()
    {
        coinsText.text = "$: " + GameManager.instance.Money.ToString();
    }

    public void BuyTower(int index)
    {
        GameObject towerInstance = null;
        if (towerInstance == null)
        {
            towerInstance = Instantiate(towers[index]);
            dragDrop.AddDragObject(towerInstance);
        }
    }

}
