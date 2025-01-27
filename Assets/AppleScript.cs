using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{
    public LogicManagerScript logic;
    private AudioSource logicAudio;
   
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
        logicAudio = GameObject.FindGameObjectWithTag("Logic").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9) // Check if the other object is on layer 9 (snake)
        {
            logic.addScore(1);
            
	    if (logicAudio != null)
            {
                logicAudio.Play(); // Play the audio
            }

            Destroy(gameObject); // Destroy the apple after the snake eat it
        }
    }
}
