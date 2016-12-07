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
    private int originCount;
    //User currently being scanned
    private List<int[]> confirmedTopics;
    private Dossier currentScanDossier;
    private Person currentScanPerson;
    private Personality currentScanPersonality;

    //CONSIDER: Load in batches of 10. At the end of this, send it to be displayed.
    //TODO: Define threshold ratio to consider it for matching. Note that the defaults are also part of the PersonalLike list so they will always get added to the "confirmedTopics"
    //TODO: SEE IF YOU CAN MAKE THIS CODE MORE READABLE BY HAVING SHORTER INSTRUCTIONS!!!

    private void dispatchMatchesToScreen()
    {

    }

    private void conductDeepSearch()
    {
        List<string>[] itemsInCommonPerTopic = new List<string>[confirmedTopics.Count];
        int commonTopicsCounter = 0;
        for(int i = 0; i < confirmedTopics.Count; i++)
        {
            string[] originPLikeElements = originPersonality.getPLikeAtIndex(confirmedTopics[i][0]).getFieldElements();
            string[] currentPLikeElements = currentScanPersonality.getPLikeAtIndex(confirmedTopics[i][1]).getFieldElements();

            int largerLength = originPLikeElements.Length < currentPLikeElements.Length ? currentPLikeElements.Length : originPLikeElements.Length; 

            for(int j = 0, k = 0; j <= largerLength; j++)
            {
                if(originPLikeElements[k].Equals(currentPLikeElements[j]))
                {
                    itemsInCommonPerTopic[commonTopicsCounter++].Add(currentPLikeElements[j]);
                    j = 0;
                    k++;
                    continue;
                }

                if(j == largerLength && k < originPLikeElements.Length)
                {
                    j = 0;
                    k++;
                }
            }
        }
    }

    private void searchDossier()
    {
        int currentScanCount = currentScanPersonality.getPreferences().Count;

        for (int i = 0, j = 0; i < currentScanCount && j < originCount; i++)
        {
            if(currentScanPersonality.getPLikeTitleAtIndex(i).Equals(originPersonality.getPLikeTitleAtIndex(j)))
            {
                confirmedTopics.Add(new int[2] {j,i});

                if(confirmedTopics.Count/originCount >= thresholdRatioForMatch)
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
        //TODO: Find a way to deep search the 4 default categories
        originCount = originPersonality.getPreferences().Count;
        for (int i = 0; i < 4; i++)
        {

        }
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
