using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animal
{
    private AudioSource catAudioSource;
    private float timeToWait;
    private float canMeow;

    private void Start()
    {
        catAudioSource = GetComponent<AudioSource>();
        timeToWait = catAudioSource.clip.length;
        canMeow = Time.time;
        Name = "Pan";
        Age = -2.2f;

        Info = "The cat's name is " + Name + " and it is " + Age + " years old.";
    }

    public override void Vocalize()
    {
        if (canMeow <= Time.time)
        {
            catAudioSource.Play();
            canMeow = Time.time + timeToWait;
        }
    }
}
