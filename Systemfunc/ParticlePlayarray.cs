using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayarray : MonoBehaviour
{
    GameObject[] particleobjs;

    void Start()
    {
        particleobjs = GameObject.FindGameObjectsWithTag("Particles");

        foreach (GameObject obs in particleobjs)
        {
            ParticleSystem particle = obs.GetComponent<ParticleSystem>();
            particle.Stop();
        }
    }

    public void ParticleOn()
    {
        StartCoroutine("PartcleStop");
    }

    IEnumerator PartcleStop()
    {
        foreach (GameObject obs in particleobjs)
        {
            ParticleSystem particle = obs.GetComponent<ParticleSystem>();
            particle.Play();
        }
        yield return new WaitForSeconds(2);
        foreach (GameObject obs in particleobjs)
        {
            ParticleSystem particle = obs.GetComponent<ParticleSystem>();
            particle.Stop();
        }
    }
}
