using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public string Name { get; private set; }

    private float age;
    public float Age
    {
        get { return age; }
        set 
        {
            if (value < 0)
            {
                Debug.LogError("Age cannot be set to negative number.");
                return;
            }
            age = value;
        }
    }

    protected virtual void Vocalize()
    {
        Debug.Log("Animal base class Vocalize() method has been called. You should never see this.");
    }
}
