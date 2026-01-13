using UnityEngine;

public class DeathScreenUI : MonoBehaviour
{
    public GameObject deathScreen;

    void OnEnable()
    {
        PlayerEvents.OnPlayerDied += Show;
    }

    void OnDisable()
    {
        PlayerEvents.OnPlayerDied -= Show;
    }

    void Show()
    {
        if (deathScreen != null)
            deathScreen.SetActive(true);
            Time.timeScale = 0f;

    }
}
