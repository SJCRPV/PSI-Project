using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SearchAlgorithm : MonoBehaviour {

    public float thresholdRatioForMatch;
    //Defaults to 10 at this point.
    public int sizeOfMatchBatch = 10;

    private List<Dossier> confirmedMatches;
    private List<Dossier> currentDossier10Batch;
    //User requesting the scan
    private Dossier originDossier;
    private Person originPerson;
    private Personality originPersonality;
    //User currently being scanned
    private List<string> confirmedTopics;
    private Dossier currentScanDossier;
    private Person currentScanPerson;
    private Personality currentScanPersonality;

    //THINKING: Load in batches of 10. At the end of this, send it to be displayed.
    //TODO: Define threshold ratio to consider it for matching 

    private void dispatchMatchesToScreen()
    {

    }

    private void conductDeepSearch()
    {

    }

    private void searchDossier()
    {
        int currentScanCount = currentScanPersonality.getPreferences().Count;
        int originScanCount = originPersonality.getPreferences().Count;
        int matchedTopicsCount = 0;

        for (int i = 0, j = 0; i < currentScanCount && j < originScanCount; i++)
        {
            if(currentScanPersonality.getPLikeTitleAtIndex(i).Equals(originPersonality.getPLikeTitleAtIndex(j)))
            {
                matchedTopicsCount++;
                confirmedTopics.Add(currentScanPersonality.getPLikeTitleAtIndex(i));
                if(matchedTopicsCount/originScanCount >= thresholdRatioForMatch)
                {
                    confirmedMatches.Add(currentScanDossier);
                    if(confirmedMatches.Count % sizeOfMatchBatch == 0)
                    {
                        dispatchMatchesToScreen();
                    }
                    conductDeepSearch();
                }
            }

            if(i >= currentScanCount)
            {
                j++;
                i = 0;
            }
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
