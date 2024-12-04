using UnityEngine;

public class WeaponCollision : MonoBehaviour
{
    public GameObject weapon;
    public ScoreCounter scoreCounter; // Referenz zum ScoreCounter

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Balls"))
        {
            Destroy(collision.gameObject);
            scoreCounter.IncrementScore(); // Score erhöhen
        }
    }
}