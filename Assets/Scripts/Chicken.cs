using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Animal
{
    private AudioSource chickenAudioSource;
    private float timeToWait;
    private float canCluck;

    // Start is called before the first frame update
    void Start()
    {
        chickenAudioSource = GetComponent<AudioSource>();
        timeToWait = chickenAudioSource.clip.length;
        canCluck = Time.time;
        Name = "McFly";
        Age = 4.9f;
    }

    public override void Vocalize()
    {
        if (canCluck <= Time.time)
        {
            chickenAudioSource.Play();
            canCluck = Time.time + timeToWait;
        }
    }
}
