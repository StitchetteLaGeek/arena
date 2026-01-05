using UnityEngine;
using TMPro; // nécessaire si tu utilises TextMeshPro

public class TutorielMenu : MonoBehaviour
{
    // Panel du tutoriel à activer/désactiver
    public GameObject tutorielPanel;

    // Le composant texte à l'intérieur du panel
    public TextMeshProUGUI tutorielText;

    // Texte du tutoriel
    private string texteTutoriel = 
@"Bienvenue dans l’Arène !

Salut aventurier !

Dans cette arène, ton objectif est simple : survivre et montrer tes réflexes. 🏹

- Esquive les flèches des archers ennemis en bougeant rapidement.
- Utilise ton bouclier pour te protéger des attaques.
- Chaque attaque bloquée ou esquivée te rapproche de la victoire !

Attention : les archers deviennent plus rapides au fil du temps.
Reste concentré, observe leurs mouvements et anticipe leurs tirs.

Quand tu es prêt, ferme ce tutoriel et entre dans l’arène !";

    // Ouvre le tutoriel et affiche le texte
    public void OpenTutoriel()
    {
        tutorielPanel.SetActive(true);
        tutorielText.text = texteTutoriel;
    }

    // Ferme le tutoriel
    public void CloseTutoriel()
    {
        tutorielPanel.SetActive(false);
    }
}
