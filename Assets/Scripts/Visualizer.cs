using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Visualizer : MonoBehaviour {
	public Color visualizerColor = Color.cyan;
	public float minHeight = 15.0f;
	public float maxHeight = 320.0f;
	public float updateSensitivity = 0.20f;
	public AudioClip audioClip;
	public bool loop = true;
	public int visualizerSimples = 1024; //2048
	private VisualizerObjects[] visualizerObjects;
	public AudioSource audioSource;

	// Use this for initialization
	void Start () {
		visualizerObjects = GetComponentsInChildren<VisualizerObjects>();

		if(!audioClip) {
			return;
		}
			audioSource = new GameObject("AudioSource").AddComponent<AudioSource>();
			audioSource.loop = loop;
			audioSource.clip = audioClip;
			audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		float[] spectrumData = audioSource.GetSpectrumData(visualizerSimples, 0, FFTWindow.Rectangular); 

		for (int i = 0; i < visualizerObjects.Length; i++) {
			Vector3 newSize = visualizerObjects[i].GetComponent<RectTransform>().rect.size;
			newSize.y = Mathf.Clamp(Mathf.Lerp(newSize.y, minHeight + (spectrumData[i] * (maxHeight - minHeight) * 5.0f), updateSensitivity), minHeight, maxHeight);
			visualizerObjects[i].GetComponent<RectTransform>().sizeDelta = newSize;
			visualizerObjects[i].GetComponent<Image>().color = visualizerColor;
		}
	}
}
