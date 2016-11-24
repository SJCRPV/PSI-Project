using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwapContentOnClick : MonoBehaviour {

    [SerializeField]
    private Sprite idleSprite;
    [SerializeField]
    private Sprite clickedSprite;
    private Text contentTextScript;
    private Text buttonTextScript;
    private Image imageScript;

    private void swapText()
    {
        contentTextScript.text = imageScript.gameObject.transform.GetChild(0).GetComponent<Text>().text;
    }

    public void swapSprite()
    {
        if(imageScript.sprite != clickedSprite)
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

	// Use this for initialization
	void Start () {
        imageScript = this.gameObject.GetComponent<Image>();
        buttonTextScript = this.gameObject.GetComponentInChildren<Text>();
        if(buttonTextScript == null)
        {
            Debug.LogError("buttonTextScript is empty");
        }
        contentTextScript = GameObject.Find("Content").gameObject.GetComponentInChildren<Text>();
	}
}
