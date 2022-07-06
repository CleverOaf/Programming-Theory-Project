using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animal
{
    private AudioSource catAudioSource;
    private float timeToWait = 5;
    private float canMeow;

    // Start is called before the first frame update
    void Start()
    {
        catAudioSource = GetComponent<AudioSource>();
        canMeow = Time.time;
        Name = "Pan";
        Age = 2.2f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Vocalize()
    {
        if (canMeow <= Time.time)
        {
            catAudioSource.Play();
            canMeow = Time.time + timeToWait;
        }
    }
}
