using System;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject button;
    [SerializeField] private TMPro.TextMeshProUGUI coinsText;

    [SerializeField] private List<Slot> slots = new List<Slot>();

    [SerializeField] private DragDrop dragDrop;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        coinsText.text = "$: " + GameManager.instance.Money.ToString();
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].priceTxt.text = slots[i].price.ToString();
        }
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
        if (slots[index].price <= GameManager.instance.Money)
        {
            GameObject towerInstance = null;
            if (towerInstance == null)
            {
                towerInstance = Instantiate(slots[index].prefabTower);
                dragDrop.AddDragObject(towerInstance);
                GameManager.instance.Money -= slots[index].price;
            }
        }
        
    }

}
[Serializable]
public class Slot
{
    public GameObject prefabTower;
    public TMPro.TextMeshProUGUI priceTxt;
    public float price;



}