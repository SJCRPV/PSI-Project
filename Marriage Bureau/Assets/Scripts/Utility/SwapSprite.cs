using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapSprite : MonoBehaviour {

    public Sprite swapSpriteTo;
    
    public void onClick()
    {
        gameObject.GetComponent<Image>().sprite = swapSpriteTo;
    }
}
