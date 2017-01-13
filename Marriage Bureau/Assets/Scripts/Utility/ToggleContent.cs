using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleContent : MonoBehaviour
{
    [SerializeField]
    private Sprite inactiveSprite;
    [SerializeField]
    private Sprite activeSprite;
    [SerializeField]
    private Color activeColour;
    [SerializeField]
    private Color inactiveColour;
    [SerializeField]
    private GameObject[] objectsToHide;
    [SerializeField]
    private GameObject[] objectsToShow;
    [SerializeField]
    private bool isActive;
    [SerializeField]
    private Image triggerObjectImageScript;

    private void swapSprite()
    {
        if (isActive)
        {
            triggerObjectImageScript.sprite = activeSprite;
        }
        else
        {
            triggerObjectImageScript.sprite = inactiveSprite;
        }
    }

    private void activateObjects()
    {
        if (isActive)
        {
            for (int i = 0; i < objectsToShow.Length; i++)
            {
                objectsToShow[i].transform.gameObject.SetActive(true);
            }
        }
    }

    private void deactivateObjects()
    {
        if (isActive)
        {
            for (int i = 0; i < objectsToShow.Length; i++)
            {
                objectsToHide[i].transform.gameObject.SetActive(false);
            }
        }
    }

    private void flipIsActive()
    {
        isActive = !isActive;
    }

    public void onClick()
    {
        flipIsActive();
        swapSprite();
        activateObjects();
        deactivateObjects();
    }

    void Start()
    {
        triggerObjectImageScript = gameObject.GetComponent<Image>();
    }
}