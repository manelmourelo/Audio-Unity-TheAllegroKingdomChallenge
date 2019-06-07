using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioZoneManager : MonoBehaviour {

    AudioSource source;

    public AudioClip caveClip;
    public AudioClip desertClip;
    public AudioClip forgeClip;
    public AudioClip dungeonClip;
    public AudioClip villageClip;
    public AudioClip magicHouseClip;
    public AudioClip woodLandsClip;
    public AudioClip pineForestClip;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();

    }

    public void PlayZoneAudio(ZoneTrigger.MusicState state) {
        Debug.Log(state.ToString());
        switch (state)
        {
            case ZoneTrigger.MusicState.CAVE:
                source.clip = caveClip;
                source.Play();
                break;
            case ZoneTrigger.MusicState.DESERT:
                source.clip = desertClip;
                source.Play();
                break;
            case ZoneTrigger.MusicState.FORGE:
                source.clip = forgeClip;
                source.Play();
                break;
            case ZoneTrigger.MusicState.DUNGEON:
                source.clip = dungeonClip;
                source.Play();
                break;
            case ZoneTrigger.MusicState.VILLAGE:
                source.clip = villageClip;
                source.Play();
                break;
            case ZoneTrigger.MusicState.MAGICHOUSE:
                source.clip = magicHouseClip;
                source.Play();
                break;
            case ZoneTrigger.MusicState.WOODLANDS:
                source.clip = woodLandsClip;
                source.Play();
                break;
            case ZoneTrigger.MusicState.PINEFOREST:
                source.clip = pineForestClip;
                source.Play();
                break;
            default:
                break;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
