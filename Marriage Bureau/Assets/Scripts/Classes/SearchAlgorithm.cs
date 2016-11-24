using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SearchAlgorithm : MonoBehaviour {

    private List<Dossier> confirmedMatches;
    private List<Dossier> currentDossier10Batch;
    //User requesting the scan
    private Dossier originDossier;
    private Person originPerson;
    private Personality originPersonality;
    //User currently being scanned
    private Dossier currentScanDossier;
    private Person currentScanPerson;
    private Personality currentScanPersonality;

    //THINKING: Load in batches of 10. At the end of this, send it to be displayed.

    private void searchDossier()
    {
        foreach(PersonalLike in originPersonality)
        {

        }
    }

	// Use this for initialization
	void Start ()
    {
        //Dummy code to get access to the intellisense. This is probably even in the wrong place.
        originDossier = GameObject.Find("User").GetComponent<Dossier>();
        originPerson = originDossier.GetComponent<Person>();
        originPersonality = originPerson.GetComponent<Personality>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
