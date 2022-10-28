using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over : MonoBehaviour
{
    public GameObject gameOverUI;

    public static Game_Over instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'instance de Game_Over ici");
            return;
        }


        instance = this;
    }

    public void OnPlayerDeath()
    {
        gameOverUI.SetActive(true);
    }

    public void RecommencerButton()
    {
        SceneManager.LoadScene("Niveau_1");
        gameOverUI.SetActive(false);

    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Menu_Principal");

    }


}
