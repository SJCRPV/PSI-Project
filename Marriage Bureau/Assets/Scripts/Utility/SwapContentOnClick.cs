using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwapContentOnClick : MonoBehaviour
{

    [SerializeField]
    private Sprite inactiveSprite;
    [SerializeField]
    private Sprite activeSprite;
    [SerializeField]
    private float activeHeight;
    [SerializeField]
    private float inactiveHeight;
    [SerializeField]
    private string parentName;

    private GameObject parentContent;
    private Image imageScript;
    private Text textScript;
    private RectTransform objectRectTransform;
    private string associatedContent;

    private void swapSprite(bool isActive)
    {
        if (isActive)
        {
            imageScript.sprite = activeSprite;
        }
        else
        {
            imageScript.sprite = inactiveSprite;
        }
    }

    private void swapTextColour(bool isClicked)
    {
        if (isClicked)
        {
            textScript.color = Color.white;
        }
        else
        {
            textScript.color = Color.black;
        }
    }

    private void adjustObjectHeight(bool isClicked)
    {
        if (isClicked)
        {
            objectRectTransform.sizeDelta = new Vector2(objectRectTransform.rect.width, activeHeight);
        }
        else
        {
            objectRectTransform.sizeDelta = new Vector2(objectRectTransform.rect.width, inactiveHeight);
        }
    }

    private void changeSetActive(bool isActive)
    {
        if (isActive)
        {
            parentContent.transform.Find(associatedContent).gameObject.SetActive(isActive);
        }
        else
        {
            parentContent.transform.Find(associatedContent).gameObject.SetActive(isActive);
        }
    }

    public void onClick(bool isClicked)
    {
        swapSprite(isClicked);
        swapTextColour(isClicked);
        adjustObjectHeight(isClicked);
        changeSetActive(isClicked);
    }

    void Start()
    {
        imageScript = gameObject.GetComponentInChildren<Image>();
        textScript = gameObject.transform.GetChild(0).gameObject.GetComponentInChildren<Text>();
        objectRectTransform = gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        parentContent = GameObject.Find(parentName);
        associatedContent = gameObject.name;
    }
}