using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuertaALV : MonoBehaviour
{
    public Sprite ClosetOpen;
    public GameObject personaje;
    public GameObject boton;
    public RectTransform posBoton;
    //first you need the RectTransform component of your canvas

    bool triggered = false;

    void Start()
    {
        //boton.GetComponent<RectTransform>().localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        boton.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
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
        triggered = false;
        boton.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && triggered)
            this.GetComponent<SpriteRenderer>().sprite = ClosetOpen;
    }


}