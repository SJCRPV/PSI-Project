using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SearchAlgorithm : MonoBehaviour {

    public float minimumRatioForMatch;
    //Defaults to 4 at this point.
    public int sizeOfMatchBatch = 4;

    private InteractWithDB dbInteractionScript;
    private long userCount;

    private List<Dossier> confirmedMatches;
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

    //CONSIDER: Load in batches of 4. At the end of this, send it to be displayed.
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

                if(confirmedTopics.Count/originCount >= minimumRatioForMatch)
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

    private void buildCurrentScanDossier(long dossierID, bool isPremium, string[] deets, string[] hobbies)
    {
<<<<<<< HEAD
        PersonalLike newTraits = new PersonalLike("Traits", new string[] { "" });
        PersonalLike newFilms = new PersonalLike("Films", new string[] { "" });
        PersonalLike newColours = new PersonalLike("Colours", new string[] { "" });
        PersonalLike newSongs = new PersonalLike("Songs", new string[] { "" });
        List<PersonalLike> newExtras = new List<PersonalLike>();
        currentScanPersonality = new Personality(newTraits, newFilms, newColours, newSongs, newExtras);
        currentScanPerson = new Person(deets[0], Convert.ToBoolean(deets[1]), Convert.ToInt32(deets[2]), deets[3], deets[4], currentScanPersonality);
        currentScanDossier = new Dossier(dossierID, isPremium, currentScanPerson);
=======

        //currentScanPersonality = new Personality(newTraits, newFilms, newColours, newSongs, newExtras);
        //currentScanPerson = new Person(newFullName, newIsMale, newAge, newAddress, newProfilePhoto, currentScanPersonality);
        //currentScanDossier = new Dossier(dossierID, isPremium, currentScanPerson);
>>>>>>> 76410a44528815873431b25615d7724189a43275
    }

    private IEnumerator initiateSearch()
    {
        dbInteractionScript.getFromDB("http://psiwebservice/getTotalUserCount.php");
        while(dbInteractionScript.IsRequesting)
        {
            yield return null;
        }
        userCount = Convert.ToInt64(dbInteractionScript.CleanData[0]);

        for(int i = 0; i < userCount; i++)
        {
            dbInteractionScript.getSingleFromDB("http://psiwebservice/FetchID.php", new string[2] { "id", i.ToString() });
            while (dbInteractionScript.IsRequesting)
            {
                yield return null;
            }
            long dossierID = Convert.ToInt64(dbInteractionScript.CleanData[0]);

            dbInteractionScript.getSingleFromDB("http://psiwebservice/fetchIsPremium.php", new string[2] { "id", i.ToString() });
            while (dbInteractionScript.IsRequesting)
            {
                yield return null;
            }
            bool isPremium = Convert.ToBoolean(dbInteractionScript.CleanData[0]);

            dbInteractionScript.getSingleFromDB("http://psiwebservice/getDeetsOfID.php", new string[2] { "id", i.ToString() });
            while (dbInteractionScript.IsRequesting)
            {
                yield return null;
            }
            string[] = dbInteractionScript.CleanData;

            dbInteractionScript.getSingleFromDB("http://psiwebservice/getHobbiesOfID.php", new string[2] { "id", i.ToString()});
            while(dbInteractionScript.IsRequesting)
            {
                yield return null;
            }
            string[] hobbyIDs = dbInteractionScript.CleanData;
<<<<<<< HEAD
            buildCurrentScanDossier(dossierID, isPremium, )
=======
            // currentScanDossier = new Dossier();
>>>>>>> 76410a44528815873431b25615d7724189a43275
        }

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
        originDossier = GameObject.Find("User").GetComponent<Dossier>();
<<<<<<< HEAD
        originPerson = new Person();
        originPersonality = new Personality();
=======
        //originPerson = originDossier.GetComponent<Person>();
        //originPersonality = originPerson.GetComponent<Personality>();
>>>>>>> 76410a44528815873431b25615d7724189a43275
        dbInteractionScript = GameObject.Find("HolderOfValues").GetComponent<InteractWithDB>();
        initiateSearch();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
