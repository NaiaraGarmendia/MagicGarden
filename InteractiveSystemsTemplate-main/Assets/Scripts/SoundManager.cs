using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance; 

    public AudioClip Watering;
    public AudioClip tierra;
    public AudioClip pickup;
    public AudioClip drop;
    public AudioClip harvest;

    public Camera Camera;

    private Vector3 cameraPosition; 
    // Start is called before the first frame update
    void Awake(){
        Instance = this;
        cameraPosition = Camera.transform.position; 
       
    }
    private void PlaySound(AudioClip clip){
        AudioSource.PlayClipAtPoint(clip, cameraPosition); 
       
    }

    public void PlayWater()
    {
        PlaySound(Watering);
    }

    public void Playtierra()
    {
        PlaySound(tierra);
       
    }

    public void Playpickup()
    {
        PlaySound(pickup);

    }

    public void Playdrop()
    {
        PlaySound(drop);

    }

    public void PlayHarvest()
    {
        PlaySound(harvest);

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
