using UnityEngine;
using Random = UnityEngine.Random;

public class GameMode2 : GameMode
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
        random = Random.Range(0, 10);

        if (random != 10)
            LeanTween.move(gameObject, locations[random].position, 3f * Time.deltaTime);

        particle.Play();
    }
}
