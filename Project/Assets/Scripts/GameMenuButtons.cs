using UnityEngine;
using System.Collections;

public class GameMenuButtons : MonoBehaviour {

	public enum GameMenuButton {Resume, MainMenu, Music, Effects}
	public GameMenuButton button;

	private Pauser pauser;
	// Use this for initialization
	void Start () {

		GameObject menu = GameObject.Find ("MenuButton"); 
		pauser = menu.GetComponent<Pauser>();

	
	}
	
	// Update is called once per frame
	void OnMouseDown() {
		if (button == GameMenuButton.Resume)
						pauser.paused = false;
		if (button == GameMenuButton.MainMenu)
						Application.LoadLevel ("MainMenu");
		if (button == GameMenuButton.Music)
						MusicChanger ();
		if (button == GameMenuButton.Effects)
						EffectsChanger ();
		
	}

	void MusicChanger() {
		GameObject musicDisableButton = transform.parent.FindChild ("MusicDisabled").gameObject;
		Debug.Log ("Music Changer: " + musicDisableButton.activeSelf);
		musicDisableButton.SetActive (!musicDisableButton.activeSelf);
		if (PlayerPrefs.GetString("Sound") == "On")
			PlayerPrefs.SetString ("Sound", "Off");
		else
			PlayerPrefs.SetString ("Sound", "Off");
	}

	void EffectsChanger() {

		GameObject effectsDisableButton = transform.parent.FindChild ("EffectsDisabled").gameObject;
		Debug.Log ("Effects Changer: " + effectsDisableButton.activeSelf);
		effectsDisableButton.SetActive (!effectsDisableButton.activeSelf);
		if (PlayerPrefs.GetString("Effects") == "On")
			PlayerPrefs.SetString ("Effects", "Off");
		else
			PlayerPrefs.SetString ("Effects", "Off");

	}
}
