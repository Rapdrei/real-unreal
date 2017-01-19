﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class movement : MonoBehaviour {

    private AudioSource audio;
    public AudioClip footstep;
    public float speed;
    private float dx, dy;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
 
         float idx = (Input.GetAxis("Horizontal")) ;
        float idy = (Input.GetAxis("Vertical"));
        transform.Translate(idx * Time.deltaTime*speed, 0f, speed*idy * Time.deltaTime,Space.Self); 
          
        dx += Abs(idx)*speed;
        dy += Abs(idy) * speed;

        if (Input.GetKey("g"))   
            transform.Rotate(0, 4, 0, Space.World);
        if (Input.GetKey("j"))
            transform.Rotate(0, -4, 0, Space.World);
       if (Input.GetKey("z"))
            transform.Rotate(2, 0, 0, Space.Self);
        if (Input.GetKey("h"))
            transform.Rotate(-2, 0, 0, Space.Self);



        if ((dx) + dy >7 )
        {
            float volume = Random.Range(0.3f, 1.2F);
            audio.PlayOneShot(footstep,volume);
            dx = 0;
            dy = 0;
        }
      
        //print();
        
    }

    private float Abs (float a)
    {
        if (a <= 0) return -a;
        return a;
    }
}
