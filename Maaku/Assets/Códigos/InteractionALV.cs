using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionALV : MonoBehaviour
{
    public GameObject closet;
    public Sprite sprite;
    public GameObject boton;
    public RectTransform posBoton;
    int countInteraction = 0;
    public GameObject itemButton;
    private Inventory inventory;
    Collider2D colisionALV;
    //first you need the RectTransform component of your canvas

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
        posBoton.anchorMin = viewportPoint;
        posBoton.anchorMax = viewportPoint;

        boton.SetActive(true);

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        colisionALV = collision;
        triggered = false;
        boton.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && triggered) { //Verifica si se presiona E para interactuar

            if (colisionALV.gameObject.name == "Closet" && countInteraction == 0)
            {

                closet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Muebles/ClosetOpen1");
                countInteraction++;
            }
            else if (colisionALV.gameObject.name == "Closet" && countInteraction == 1)
            {
                closet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Muebles/ClosetOpen2");
                itemButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/Baterias");
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
            else if (colisionALV.gameObject.name == "Closet" && countInteraction == 2)
            {
                closet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Muebles/ClosetOpen3");
                itemButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/Collar");
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
        }

    }

    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && triggered && countInteraction == 0)
        {
            print("interaccion = " + countInteraction);
            closet.GetComponent<SpriteRenderer>().sprite = closetSprite;
            countInteraction++;
        }
        else if (Input.GetKeyDown(KeyCode.E) && triggered && countInteraction == 1)
        {
            print("interaccion = " + countInteraction);
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
    }*/


}