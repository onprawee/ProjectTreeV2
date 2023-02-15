using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private int trapsDamage;
    [SerializeField] private HealthManager healthManager;

    private void OnTriggerEnter2D(Collider2D collision)
    
    {
        Debug.Log("Collision: " + collision.name);
        if (collision.CompareTag("Player"))

        {
            Demage();
            Debug.Log("Chip");
        }
    }

    void Demage()
    {
        healthManager.playerHealth = healthManager.playerHealth - trapsDamage;
        healthManager.UpdateHealth();
        Debug.Log("Player Health: " + healthManager.playerHealth);
        gameObject.SetActive(false);
    }
}
