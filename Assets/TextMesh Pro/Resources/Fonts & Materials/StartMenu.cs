using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject tutorielPanel;

    // Lance la scène du jeu
    public void StartGame()
    {
        SceneManager.LoadScene("Scene_Game");
    }

    // Affiche le panneau du tutoriel
    public void OpenTutoriel()
    {
        tutorielPanel.SetActive(true);
    }

    // Cache le panneau du tutoriel
    public void CloseTutoriel()
    {
        tutorielPanel.SetActive(false);
    }

    // Quitte l'application
    public void QuitGame()
    {

    Application.Quit(); // ferme le jeu quand il est construit
    Debug.Log("Quitter le jeu"); // juste pour tester dans l'éditeur

    }
}

