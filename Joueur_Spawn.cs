using UnityEngine;

public class Joueur_Spawn : MonoBehaviour
{
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
    }

}
