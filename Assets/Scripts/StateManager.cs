using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates { MENU, SETTINGS, PLAY, PAUSE }

public class StateManager : MonoBehaviour {

	private GameStates currentState;
	private GameStates lastState;
	public GameStates STATE { get { return currentState; }
							  set { lastState = currentState; 
								  	currentState = value;
									ChangeState();		}}
	private Transform[] states;
	public static StateManager instance;

	// Use this for initialization
	void Start () {
		instance = this;
		states = new Transform[transform.childCount];
		currentState = GameStates.MENU;
		
		for(int i = 0; i < transform.childCount; i++) {
			states[i] = transform.GetChild(i);
			transform.GetChild(i).gameObject.SetActive(false);
		}

		states[(int)currentState].gameObject.SetActive(true);
	}

	void ChangeState() {
		if(lastState == GameStates.PLAY && currentState == GameStates.PAUSE){
			// turn on pause
			states[(int)currentState].gameObject.SetActive(true);
		} else if (lastState == GameStates.PAUSE && currentState == GameStates.PLAY) {
			// turn off just pause
			states[(int)lastState].gameObject.SetActive(false);
		} else {
			states[(int)lastState].gameObject.SetActive(false);
			states[(int)currentState].gameObject.SetActive(true);
		}
	}

}
