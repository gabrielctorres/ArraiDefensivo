using UnityEditor;
using UnityEngine;

public class UIStuff : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

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

}
