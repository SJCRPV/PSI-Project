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
    /*Tuple may not be supported by Unity.*/
    private Tuple<int, int> confirmedTopics;
    private List<int[]> confirmedTopics;
    private Dossier currentScanDossier;
    private Person currentScanPerson;
    private Personality currentScanPersonality;

    //THINKING: Load in batches of 10. At the end of this, send it to be displayed.
    //TODO: Define threshold ratio to consider it for matching. Note that the defaults are also part of the PersonalLike list so they will always get added to the "confirmedTopics"

    private void dispatchMatchesToScreen()
    {

    }

    private void conductDeepSearch()
    {
        for(int i = 0; i < confirmedTopics; i++)
        {

        }
    }

    private void searchDossier()
    {
        int currentScanCount = currentScanPersonality.getPreferences().Count;
        int originScanCount = originPersonality.getPreferences().Count;

        for (int i = 0, j = 0; i < currentScanCount && j < originScanCount; i++)
        {
            if(currentScanPersonality.getPLikeTitleAtIndex(i).Equals(originPersonality.getPLikeTitleAtIndex(j)))
            {
                //Tuple
                confirmedTopics.Add(j, i);
                //List
                confirmedTopics.Add(new int[2] {j,i});

                if(confirmedTopics.Count/originScanCount >= thresholdRatioForMatch)
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

    private void initiateSearch()
    {
        //TODO: Interact with DB to fetch user list
        /*
         * Send to DB: select * from Users
         * Probably use a cursor to insert into a list
         * 
         * for(int i = 0; i < list.Count; i++)
         * {
         *      currentScanDossier = list[i];
         *      currentScanPerson = currentScanDossier.GetComponent<Person>();
         *      currentScanPersonality = currentScanPerson.GetComponent<Personality>();
         *      searchDossier();
         * }
         * */
    }

	// Use this for initialization
	void Start ()
    {
        //Dummy code to get access to the intellisense. This is probably even in the wrong place.
        originDossier = GameObject.Find("User").GetComponent<Dossier>();
        originPerson = originDossier.GetComponent<Person>();
        originPersonality = originPerson.GetComponent<Personality>();
        initiateSearch();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
