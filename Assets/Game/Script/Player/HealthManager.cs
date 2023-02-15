using UnityEngine;
using UnityEngine.UI;


public class HealthManager : MonoBehaviour
{
    public int playerHealth;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    private void Start()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        foreach (Image heart in hearts)
        {
            heart.sprite = emptyHeart;
        }
        for (int i = 0; i < playerHealth; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }
}

