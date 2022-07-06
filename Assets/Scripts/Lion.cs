using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Lion : Animal
{
    private AudioSource lionAudioSource;
    private float timeToWait;
    private float canRoar;

    private void Start()
    {
        lionAudioSource = GetComponent<AudioSource>();
        timeToWait = lionAudioSource.clip.length;
        canRoar = Time.time;
        Name = "Snoop";
        Age = 6.6f;

        Info = "The lion's name is " + Name + " and it is " + Age + " years old.";
    }

    // POLYMORPHISM
    public override void Vocalize()
    {
        if (canRoar <= Time.time)
        {
            lionAudioSource.Play();
            canRoar = Time.time + timeToWait;
        }
    }
}
