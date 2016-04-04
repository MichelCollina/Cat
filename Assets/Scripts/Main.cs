using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;


public class Main : MonoBehaviour {

	public GameObject seasonsValue;
	public GameObject userValue;
	public GameObject imgValue;

	private Dropdown userDrop;
	private Dropdown imgDrop;
	private Dropdown particleDrop;

	public GameObject imgSprite;

	private bool control = true;

	private int defaultSelect = 0;
	private int defaultImg=0;
	private int defaultParticle = 0;

	string dataPath;
	string info;
	List<string> listImg;


	// Use this for initialization
	void Start () {

		imgValue.SetActive (false);

		imgDrop = imgValue.GetComponent<Dropdown> ();
		userDrop = userValue.GetComponent<Dropdown> ();
		particleDrop = seasonsValue.GetComponent<Dropdown> ();

		List<string> userList = new List<string> ();

		dataPath = Application.dataPath;
		info = dataPath + "/Resources/Users/";

		string [] strUser=	Directory.GetDirectories(info);

		for (int i = 0; i < strUser.Length; i++)
		{
			strUser[i] = strUser [i].Replace (info, "");
			userList.Add (strUser [i]);
		}

		userDrop.AddOptions (userList);

	}
	// Update is called once per frame
	void Update () {
		if (userDrop.value != defaultSelect)
		{
			defaultSelect = userDrop.value;
			loadDropOption();
		}
		if (imgDrop.value != defaultImg) 
		{
			defaultImg = imgDrop.value;
			changeSprite ();
		}
		if (particleDrop.value != defaultParticle) 
		{
			defaultParticle = particleDrop.value;
			changeParticle ();
		}

	}
	private void changeVisibility()
	{
		imgValue.SetActive (true);
		control = false;
	}
	private void loadDropOption()
	{
		if (control) 
		{
			changeVisibility ();
		}
		if (listImg == null)
		{
			listImg = new List<string> ();
		} 
		else
		{
			listImg.Clear ();
			listImg.Add ("");
			imgDrop.ClearOptions ();
		}

		string[] strImg = Directory.GetFiles (info + userDrop.captionText.text + "/" ,"*.png");

		for (int i = 0; i < strImg.Length; i++) 
		{
			strImg [i] = strImg [i].Replace (info + userDrop.captionText.text + "/" , "");
			strImg [i] = strImg [i].Replace (".png", "");
			listImg.Add(strImg[i]);
		}

		imgDrop.AddOptions (listImg);
		imgDrop.value = 0;
	}
	private void changeSprite()
	{ 
		imgSprite.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Users/" + userDrop.captionText.text + "/" + imgDrop.captionText.text ) as Sprite;
	}
	private void changeParticle()
	{
		Debug.Log ("Particle Changed");
	}
}