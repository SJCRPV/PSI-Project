using UnityEngine;
using System.Collections;

public class User : Dossier {
    //TODO: The whole class. 

    private void openProfile()
    {
        //TODO: Load the profile screen.
    }

    private void editProfile()
    {
        //TODO: You may want to make this a parameterized function. Have it take a string argument that contains the object to change's name and then just allow the editing of the field by making the input field interactable
    }

    private void selectForMatch()
    {
        //TODO: Have this send a request to the server to say that the match request was made. This should trigger a notification on the other side.
        //Compatible with both match requests and match confirmations
    }

    private void checkMatchRequests()
    {
        //TODO: Open section that lists all the match requests. Shouldn't have to open new scene.
    }

    private void checkComingDates()
    {
        //TODO: Open section that lists the coming dates. Time, person, photo and location. Option to open its own scene for more detailed info (like a map)
    }

    private void confirmDate()
    {
        //TODO: Can be done from both the section or the seperate scene as it should only trigger from the press of a button.
    }

    private void updateMatchList()
    {
        //TODO: Request new match list from the DB.
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
