using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    [Header("Parallax Managers")]
    public GameObject[] normalManagers;
    public GameObject[] snowManager;

    [Header("Particles")]
    public GameObject snowsParticles;

    private bool isSnow = false;
    private float timer;
    public float themeDuration = 30f;

    void Start()
    {
        SetTheme(false);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= themeDuration)
        {
            timer = 0;
            ToggleTheme();
        }
    }

    void ToggleTheme()
    {
        isSnow = !isSnow;
        SetTheme(isSnow);
    }

    void SetTheme(bool isSnow)
    {
        foreach (var obj in normalManagers) obj.SetActive(!isSnow);
        foreach (var obj in snowManager) obj.SetActive(isSnow);

        snowsParticles.SetActive(isSnow);
    }
}
