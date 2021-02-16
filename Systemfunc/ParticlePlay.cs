using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlay : MonoBehaviour
{
    private ParticleSystem particle;

    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        particle.Stop();
    }

    public void ParticleOn()
    {
        particle.Play();
        StartCoroutine("PartcleStop");
    }

    private IEnumerator PartcleStop()
    {
        yield return new WaitForSeconds(2);
        particle.Stop();
    }
}
