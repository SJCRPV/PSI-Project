using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwapContentOnClick : MonoBehaviour
{

    [SerializeField]
    private Sprite idleSprite;
    [SerializeField]
    private Sprite clickedSprite;
    [SerializeField]
    private GameObject content;
    private GameObject paginaInicial;
    private GameObject conceitoEmpresa;
    private GameObject contactos;
    private GameObject currentActiveObject;
    private Image imageScript;


    public void swapSprite()
    {
        if (imageScript.sprite != clickedSprite)
        {
            imageScript.sprite = clickedSprite;
            buttonTextScript.color = Color.white;
            swapText();
        }
    }

    public void resetSprite()
    {
        imageScript.sprite = idleSprite;
        buttonTextScript.color = Color.black;
    }

    private void turnEverythingOff()
    {
        paginaInicial.gameObject.SetActive(false);
        conceitoEmpresa.gameObject.SetActive(false);
        contactos.gameObject.SetActive(false);
    }

    private void onClick(string objectToActivate)
    {
        currentActiveObject = GameObject.Find(objectToActivate);
        imageScript = currentActiveObject.GetComponent<Image>();
        turnEverythingOff();
        swapSprite();
        currentActiveObject.SetActive(true);

    }

    // Use this for initialization
    void Start()
    {
        content = GameObject.Find("Content");
        paginaInicial = content.transform.GetChild(0).gameObject;
        conceitoEmpresa = content.transform.GetChild(1).gameObject;
        contactos = content.transform.GetChild(2).gameObject;
    }
}