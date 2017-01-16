using UnityEngine;
using System.Collections;
<<<<<<< HEAD
using System.IO;
=======
>>>>>>> e38bc7744a569720a514f67aab10e1b80202506c

public class GoogleMap : MonoBehaviour
{
	public enum MapType
	{
		RoadMap,
		Satellite,
		Terrain,
		Hybrid
	}
	public bool loadOnStart = true;
	public bool autoLocateCenter = true;
	public GoogleMapLocation centerLocation;
	public int zoom = 13;
	public MapType mapType;
	public int size = 512;
	public bool doubleResolution = false;
	public GoogleMapMarker[] markers;
	public GoogleMapPath[] paths;
	
	void Start() {
		if(loadOnStart) Refresh();	
	}
	
	public void Refresh() {
		if(autoLocateCenter && (markers.Length == 0 && paths.Length == 0)) {
			Debug.LogError("Auto Center will only work if paths or markers are used.");	
		}
		StartCoroutine(_Refresh());
	}
	
	IEnumerator _Refresh ()
	{
		var url = "http://maps.googleapis.com/maps/api/staticmap";
		var qs = "";
		if (!autoLocateCenter) {
			if (centerLocation.address != "")
<<<<<<< HEAD
				qs += "center=" + WWW.UnEscapeURL (centerLocation.address);
			else {
				qs += "center=" + WWW.UnEscapeURL (string.Format ("{0},{1}", centerLocation.latitude, centerLocation.longitude));
=======
				qs += "center=" + WWW.UnEscapeURL(centerLocation.address);
			else {
				qs += "center=" + WWW.UnEscapeURL(string.Format ("{0},{1}", centerLocation.latitude, centerLocation.longitude));
>>>>>>> e38bc7744a569720a514f67aab10e1b80202506c
			}
		
			qs += "&zoom=" + zoom.ToString ();
		}
<<<<<<< HEAD
		qs += "&size=" + WWW.UnEscapeURL (string.Format ("{0}x{0}", size));
=======
		qs += "&size=" + WWW.UnEscapeURL(string.Format ("{0}x{0}", size));
>>>>>>> e38bc7744a569720a514f67aab10e1b80202506c
		qs += "&scale=" + (doubleResolution ? "2" : "1");
		qs += "&maptype=" + mapType.ToString ().ToLower ();
		var usingSensor = false;
#if UNITY_IPHONE
		usingSensor = Input.location.isEnabledByUser && Input.location.status == LocationServiceStatus.Running;
#endif
		qs += "&sensor=" + (usingSensor ? "true" : "false");
		
		foreach (var i in markers) {
			qs += "&markers=" + string.Format ("size:{0}|color:{1}|label:{2}", i.size.ToString ().ToLower (), i.color, i.label);
			foreach (var loc in i.locations) {
				if (loc.address != "")
<<<<<<< HEAD
					qs += "|" + WWW.UnEscapeURL (loc.address);
				else
					qs += "|" + WWW.UnEscapeURL (string.Format ("{0},{1}", loc.latitude, loc.longitude));
=======
					qs += "|" + WWW.UnEscapeURL(loc.address);
				else
					qs += "|" + WWW.UnEscapeURL(string.Format ("{0},{1}", loc.latitude, loc.longitude));
>>>>>>> e38bc7744a569720a514f67aab10e1b80202506c
			}
		}
		
		foreach (var i in paths) {
			qs += "&path=" + string.Format ("weight:{0}|color:{1}", i.weight, i.color);
			if(i.fill) qs += "|fillcolor:" + i.fillColor;
			foreach (var loc in i.locations) {
				if (loc.address != "")
					qs += "|" + WWW.UnEscapeURL (loc.address);
				else
					qs += "|" + WWW.UnEscapeURL (string.Format ("{0},{1}", loc.latitude, loc.longitude));
			}
		}

<<<<<<< HEAD
        var req = new WWW(url + "?" + qs);
        yield return req;
        byte[] bytes = req.texture.EncodeToPNG();
        File.WriteAllBytes("Assets/Img/testImage.png", bytes);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("C:/Users/SJCRPV/Documents/GitHub/PSI-Project/Marriage Bureau/Assets/Img/testImage");
        //byte[] data = File.ReadAllBytes("Assets/Img/testImage.png");


=======

        var req = new WWW(url + "?" + qs);
        yield return req;
        GetComponent<Renderer>().material.mainTexture = req.texture;


        

        
>>>>>>> e38bc7744a569720a514f67aab10e1b80202506c
    }
	
	
}

public enum GoogleMapColor
{
	black,
	brown,
	green,
	purple,
	yellow,
	blue,
	gray,
	orange,
	red,
	white
}

[System.Serializable]
public class GoogleMapLocation
{
	public string address;
	public float latitude;
	public float longitude;
}

[System.Serializable]
public class GoogleMapMarker
{
	public enum GoogleMapMarkerSize
	{
		Tiny,
		Small,
		Mid
	}
	public GoogleMapMarkerSize size;
	public GoogleMapColor color;
	public string label;
	public GoogleMapLocation[] locations;
	
}

[System.Serializable]
public class GoogleMapPath
{
	public int weight = 5;
	public GoogleMapColor color;
	public bool fill = false;
	public GoogleMapColor fillColor;
	public GoogleMapLocation[] locations;	
}