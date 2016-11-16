using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour {
    public Button button;
    public void clickTest()
    {
        Debug.Log("I was clicked! It tickles!");
    }

	// Use this for initialization
	void Start () {
        Button btn = this.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(clickTest);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
