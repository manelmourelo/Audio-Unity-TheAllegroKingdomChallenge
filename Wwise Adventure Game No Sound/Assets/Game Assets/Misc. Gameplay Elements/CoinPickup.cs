////////////////////////////////////////////////////////////////////////
//
// Copyright (c) 2018 Audiokinetic Inc. / All Rights Reserved
//
////////////////////////////////////////////////////////////////////////

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPickup : MonoBehaviour {

    public bool playSpawnSoundAtSpawn = true;
    public AudioClip pick_up_clip;

    void Start(){
        if (playSpawnSoundAtSpawn){
            // HINT: You might want to play the Coin pickup sound here
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(pick_up_clip, 0.7F);
        }
	}

	public void AddCoinToCoinHandler(){
		InteractionManager.SetCanInteract(this.gameObject, false);
		GameManager.Instance.coinHandler.AddCoin ();
		//Destroy (gameObject, 0.1f); //TODO: Pool instead?
	}
}
