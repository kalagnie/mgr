using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer1 : MonoBehaviour {

	public Text lengthText;

	public Slider slider;
	public Button playStop;
	public bool stop = true;

	AudioSource audioSource;
	public AudioClip song;

	[SerializeField]
	private Sprite[] playPauseIcons;

	//for inventory system
	public Sprite musicIcon;
	public string musicName;

	void Start () {
		audioSource = GetComponent<AudioSource> ();
		playStop.image.sprite = playPauseIcons [0];
		slider.minValue = 0;
		lengthText.text = "0:00 / 0:00";
	}
		
	void Update(){
		if (!stop) {
			slider.value += Time.deltaTime;
			var start = string.Format("{0:0}:{1:00}", Mathf.Floor(audioSource.time/60), audioSource.time % 60);
			var end = string.Format("{0:0}:{1:00}", Mathf.Floor(song.length/60), song.length % 60);
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

		playStop.image.sprite = playPauseIcons [1];

		audioSource.clip = song;
		slider.maxValue = audioSource.clip.length;
		slider.value = 0;
		audioSource.Play ();
	}

	public void StopAudio(){
		playStop.image.sprite = playPauseIcons [0];
		audioSource.Stop ();
		stop = true;
		lengthText.text = "0:00 / 0:00";
	}
}
