using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DragDrop : MonoBehaviour
{
    public GameObject objSelected;
    public float rangeSnap;

    private Vector2 oldPosition;
    private bool isValidPosition;

    bool inMousePosition = false;

    void Start()
    {
        isValidPosition = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckHitObject();
        }

        if (Input.GetMouseButton(0) && objSelected != null)
        {
            inMousePosition = true;
        }

        if (Input.GetMouseButtonUp(0) && objSelected != null)
        {
            DropObject();
        }

        if (inMousePosition) DragObject();

        if (!isValidPosition) ChangeIndicatorColor(Color.red);
        else ChangeIndicatorColor(Color.blue);
    }

    void CheckHitObject()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 20f, LayerMask.GetMask("Draggable"));

        if (hit2D.collider != null)
        {
            objSelected = hit2D.transform.gameObject;
            oldPosition = objSelected.transform.position;
            objSelected.transform.parent = this.transform; // Set parent to this object to move together
        }
    }

    void DragObject()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane + 10f));
        objSelected.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        ChangeColorSprite(0.5f);

        isValidPosition = IsValidDropPosition();
        ChangeColorSprite(isValidPosition ? 0.5f : 0.2f);
    }

    void DropObject()
    {
        if (isValidPosition)
        {
            ChangeColorSprite(1);
            if (objSelected != null) objSelected.GetComponent<Tower>().enabled = true;

            objSelected.transform.parent = null;
            objSelected = null;
            inMousePosition = false;
        }
    }



    bool IsValidDropPosition()
    {
        Collider2D[] overlap = Physics2D.OverlapCircleAll(objSelected.transform.position, 0.5f, LayerMask.GetMask("Obstaculo"));
        return overlap.Length == 0;
    }

    public void ChangeColorSprite(float alphaValue)
    {
        if (objSelected != null)
        {
            Color temp = objSelected.GetComponent<SpriteRenderer>().color;
            temp.a = alphaValue;
            objSelected.GetComponent<SpriteRenderer>().color = temp;
        }
    }
    public void ChangeIndicatorColor(Color color)
    {
        if (objSelected != null)
        {
            Color temp = color;
            temp.a = 0.2f;
            objSelected.transform.GetChild(0).GetComponent<SpriteRenderer>().color = temp;
        }
    }
}
