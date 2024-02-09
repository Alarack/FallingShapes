using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public AudioClip pickUpSound;

    private AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D other) {

        CollectibleObject collectible = other.GetComponent<CollectibleObject>();

        if (collectible != null) {
            collectible.Collect();
            audioSource.PlayOneShot(pickUpSound);
        }

    }



}
