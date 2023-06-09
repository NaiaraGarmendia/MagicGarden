using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance; 

    public AudioClip Watering;
    public AudioClip tierra; 
    

    private Vector3 cameraPosition;

    // Start is called before the first frame update
    void Awake(){
        Instance = this; 
        cameraPosition = Camera.main.transform.position; 
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



    // Update is called once per frame
    void Update()
    {
        
    }
}
