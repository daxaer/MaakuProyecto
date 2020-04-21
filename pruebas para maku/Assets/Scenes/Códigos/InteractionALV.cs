using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractionALV : MonoBehaviour
{
    public GameObject closet;
    public GameObject Cofre;
    public Text dialogo;
    public GameObject boton;
    public GameObject itemButton;
    private Inventory inventory;
    Collider2D colisionALV;

    int countInteraction = 0;
    bool triggered = false;
    Vector3 posDefault = new Vector3(0, 15, 0);
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();      
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        colisionALV = collision;
        triggered = true;
        Vector3 posObjeto = new Vector3(collision.transform.position.x, 3.5f, 0);
        boton.transform.position = posObjeto;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        colisionALV = collision;
        triggered = false;
        boton.transform.position = posDefault;
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

            //------------------------------------------Cofre-------------------------------------------

            if (colisionALV.gameObject.name == "CofreClosed") //Abre el cofre
            {
                Cofre.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Muebles/CofreOpen");
                colisionALV.gameObject.name = "CofreOpen";
            }
            else if(colisionALV.gameObject.name == "CofreOpen")
            {
                dialogo.text = "-Obtuve a Teddy...";
                itemButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/Teddy");
                colisionALV.gameObject.name = "CofreOpen*";
                CheckInventory();
            }

            //------------------------------------------------------------------------------------------------------

            if (colisionALV.gameObject.name == "Puerta")
            {
                SceneManager.LoadScene("Patio");
            }

        }

    }


}