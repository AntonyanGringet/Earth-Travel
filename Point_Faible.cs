using UnityEngine;

public class Point_Faible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(transform.parent.gameObject);
        }
    }

}
