using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{
    public ParticleSystem magnetParticles;

    void Update()
    {
        bool isMagnet = GameManager.Instance.isMagnetActive;

        if (isMagnet && !magnetParticles.isPlaying)
            magnetParticles.Play();
        else if (!isMagnet && magnetParticles.isPlaying)
            magnetParticles.Stop();
    }
}
