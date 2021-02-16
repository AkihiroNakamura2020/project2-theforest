using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormParticlePlay : MonoBehaviour
{
    private ParticleSystem particle;

    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        //particle.Stop();

        particle.Play();
        StartCoroutine("PartcleStop");

        if (this.transform.parent != null)
         {
            this.transform.parent = null;
         }
    }

    /*
     public void ParticleOn()
    {
        particle.Play();
        StartCoroutine("PartcleStop");
    }
    */

    private IEnumerator PartcleStop()
    {
        yield return new WaitForSeconds(1);
        particle.Stop();
    }
}
