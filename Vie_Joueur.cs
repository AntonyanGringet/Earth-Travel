using UnityEngine;

public class Vie_Joueur : MonoBehaviour
{
    public int maxVie = 1;
    public int currentVie;

    void Start()
    {
        currentVie = maxVie;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(1);
        }
        
    }

    public void TakeDamage(int damage)
    {
        currentVie -= damage;
        if (currentVie <= 0)
        {
            Die();
            return;
        }
    }

    public void Die()
    {
        Debug.Log("Lejoueur est éliminé");
        Déplacement_Personnage.instance.enabled = false;
        Game_Over.instance.OnPlayerDeath();

    }
}
