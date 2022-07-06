using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : Animal
{
    private AudioSource lionAudioSource;
    private float timeToWait;
    private float canRoar;

    // Start is called before the first frame update
    void Start()
    {
        lionAudioSource = GetComponent<AudioSource>();
        timeToWait = lionAudioSource.clip.length;
        canRoar = Time.time;
        Name = "Snoop";
        Age = 6.6f;
    }

    public override void Vocalize()
    {
        if (canRoar <= Time.time)
        {
            lionAudioSource.Play();
            canRoar = Time.time + timeToWait;
        }
    }
}
