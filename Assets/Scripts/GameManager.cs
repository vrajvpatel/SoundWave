using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// place holder, need more information.
public class Settings {
	public float sfxVolume;
	public float musicVolume;
	public bool turnOffAnimations;

	Settings() {
		sfxVolume = 100;
		musicVolume = 100;
		turnOffAnimations = false;
	}
}

/// <summary>
/// Used to store settings, scores, and read / write
/// </summary>
public class GameManager : MonoBehaviour {

	const string SETTINGSPATH = "Assets/settings.dat";
	const string SCORESPATH = "Assets/scores.dat";
	private Settings gameSettings;
	Dictionary<string,int> Scores = new Dictionary<string, int>();
	private static GameManager instance;
	public GameManager Instance { get { return instance; }}

	void Start () {
		instance = this;

		if(!File.Exists(SETTINGSPATH)) {
			File.Create(SETTINGSPATH);
		} else {
			ReadSettings();
		}

		if(!File.Exists(SCORESPATH)) {
			File.Create(SCORESPATH);
		} else {
			ReadScores();
		}
	}


	// READ THE FILE
	private void ReadSettings() {

	}

	private void ReadScores() {

	}

	// WRITE THE FILE
	private void WriteSettings() {
		
	}

	private void WriteScores() {

	}



	/// <summary>
	/// Callback sent to all game objects before the application is quit.
	/// </summary>
	void OnApplicationQuit() {
		WriteSettings();
		WriteScores();
	}
}