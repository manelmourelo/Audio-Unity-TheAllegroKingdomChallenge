using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMusicCredits : MonoBehaviour {

    private AudioSource source;
    public float fade_decrement = 0.3f;
    private float fade_time = 1.0f / 20.0f;

    private float credits_duration_timer = 0.0f;
    private float credits_duration_sec = 88.0f;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        credits_duration_timer += Time.deltaTime;
        if(credits_duration_timer >= credits_duration_sec)
        {
            StartCoroutine("FadeOut");
            credits_duration_timer = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            StartCoroutine("FadeOut");


    }

    public IEnumerator FadeOut()
    {
        while (source.volume > 0.0f)
        {
            source.volume -= Time.deltaTime * fade_decrement;
            yield return new WaitForSeconds(fade_time);

        }
    }
}
