using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Chicken : Animal
{
    private AudioSource chickenAudioSource;
    private float timeToWait;
    private float canCluck;

    private void Start()
    {
        chickenAudioSource = GetComponent<AudioSource>();
        timeToWait = chickenAudioSource.clip.length;
        canCluck = Time.time;
        Name = "McFly";
        Age = 4.9f;

        Info = "The chicken's name is " + Name + " and it is " + Age + " years old.";
    }

    // POLYMORPHISM
    public override void Vocalize()
    {
        if (canCluck <= Time.time)
        {
            chickenAudioSource.Play();
            canCluck = Time.time + timeToWait;
        }
    }
}
