using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Vie_Joueur playerHealth = collision.transform.GetComponent<Vie_Joueur>();
            playerHealth.TakeDamage(1);
        }
    }




}
