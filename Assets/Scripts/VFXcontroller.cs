using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXcontroller : MonoBehaviour
{
    public ParticleSystem crashParticle;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }


    //Play sound on collision
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Vehicle"))
        {
            crashParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
