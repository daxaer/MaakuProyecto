using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionALV : MonoBehaviour
{
    public GameObject closet;
    public Text dialogo;
    public GameObject boton;
    public GameObject itemButton;
    private Inventory inventory;
    Collider2D colisionALV;

    int countInteraction = 0;
    bool triggered = false;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        //boton.GetComponent<RectTransform>().localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        boton.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        colisionALV = collision;
        triggered = true;
        Vector2 pos = this.transform.position;  // get the game object position
        Vector2 viewportPoint = Camera.main.WorldToViewportPoint(pos);  //convert game object position to ViewportPoint

        // set MIN and MAX Anchor values(positions) to the same position (ViewportPoint)
        boton.GetComponent<RectTransform>().anchorMin = viewportPoint;
        boton.GetComponent<RectTransform>().anchorMax = viewportPoint;

        boton.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        colisionALV = collision;
        triggered = false;
        boton.SetActive(false);
    }

    void CheckInventory()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                //Item can be added
                inventory.isFull[i] = true;
                Instantiate(itemButton, inventory.slots[i].transform, false);
                break;
            }
        }
        countInteraction++;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && triggered) { //Verifica si se presiona E para interactuar

            if (colisionALV.gameObject.name == "Closet" && countInteraction == 0) //Abre el closet
            {
                closet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Muebles/ClosetOpen1");
                countInteraction++;
            }
            else if (colisionALV.gameObject.name == "Closet" && countInteraction == 1) //Obtiene las baterías
            {
                dialogo.text = "-Obtuve unas baterías...";
                closet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Muebles/ClosetOpen2");
                itemButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/Baterias");
                CheckInventory();
            }
            else if (colisionALV.gameObject.name == "Closet" && countInteraction == 2) //Obtiene el collar
            {
                dialogo.text = "-Obtuve un collar...";
                closet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Muebles/ClosetOpen3");
                itemButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/Collar");
                CheckInventory();
            }
            else if (colisionALV.gameObject.name == "Closet" && countInteraction == 3)
            {
                dialogo.text = "";
            }

        }

    }


}