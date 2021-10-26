using System;
using System.Net.Sockets;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameMode1 : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private Transform[] locations;

    private int random;

    private void Start()
    {
        ChangePosition();
    }

    public void ChangePosition()
    {
        random = Random.Range(0, 11);

        if (random != 11)
        {
            LeanTween.move(gameObject, locations[random].position, 3f * Time.deltaTime);
            LeanTween.scale(gameObject, locations[random].localScale, 3f * Time.deltaTime);
            
            LeanTween.move(particle.gameObject, locations[random].position, 3f * Time.deltaTime);
            
            LeanTween.scale(particle.gameObject, locations[random].localScale, 3f * Time.deltaTime);

            particle.Play();
        }
    }
}
