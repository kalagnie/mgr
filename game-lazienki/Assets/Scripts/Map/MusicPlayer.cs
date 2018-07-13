using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour {

	public int currentMusic = 0;
	public AudioClip[] songs;
	AudioSource audioSource;
	public Text musicName;
	public Slider slider;
	public Text lengthText;

	public bool stop = true;
	public Button playPause;
	public Sprite[] playPauseIcons;



	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		playPause.image.sprite = playPauseIcons [0];
		slider.minValue = 0;
		musicName.text = audioSource.clip.name;
		lengthText.text = "0:00 / 0:00";
	}

	void Update(){
		if (!stop) {
			slider.value += Time.deltaTime;
			var start = string.Format("{0:0}:{1:00}", Mathf.Floor(audioSource.time/60), audioSource.time % 60);
			var end = string.Format("{0:0}:{1:00}", Mathf.Floor(songs [currentMusic].length/60), songs [currentMusic].length % 60);
			lengthText.text = start + " / " + end;
		}
	}

	public void PlayMusic(){
		if (stop)
			StartAudio ();
		else
			StopAudio ();
	}

	void StartAudio (){
		if (stop)
			stop = false;

		playPause.image.sprite = playPauseIcons [1];

		audioSource.clip = songs[currentMusic];
		musicName.text = audioSource.clip.name;
		slider.maxValue = audioSource.clip.length;
		slider.value = 0;
		audioSource.Play ();
	}

	public void StopAudio(){
		playPause.image.sprite = playPauseIcons [0];
		audioSource.Stop ();
		stop = true;
		lengthText.text = "0:00 / 0:00";
	}

	public void SetCurrentMusic (int i)
	{
		currentMusic = i;
		audioSource.clip = songs[currentMusic];
		musicName.text = audioSource.clip.name;
	}

	/*
	public void AddCurrentMusic ()
	{
		if (currentMusic == 0)
			GameState.AddItem (3);
		else if (currentMusic == 1)
			GameState.AddItem (4);	
	}
	*/
}
