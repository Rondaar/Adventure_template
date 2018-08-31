using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustParticlesController : MonoBehaviour {

    [SerializeField]
    ParticleSystem leftPs;
    [SerializeField]
    ParticleSystem rightPs;
	
    public void PlayRightPs()
    {
        rightPs.Play();
    }

    public void PlayLeftPs()
    {
        leftPs.Play();
    }

}
