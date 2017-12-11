using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    private AudioSource arrowSound;

    void Start()
    {
        arrowSound = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        arrowSound.PlayOneShot(arrowSound.clip);
    }

}
