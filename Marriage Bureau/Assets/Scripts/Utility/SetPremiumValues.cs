using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPremiumValues : MonoBehaviour {

    [SerializeField]
    private bool isMonthly;
    [SerializeField]
    private string destinationURL;

    private StaticScript staticScript;

    public void sendValuesToStaticScript()
    {
        staticScript.setIsMonthlyPremium(isMonthly);
        staticScript.setDestinationURL(destinationURL);
    }

	// Use this for initialization
	void Start () {
        staticScript = GameObject.Find("HolderOfValues").GetComponent<StaticScript>();
	}
}
