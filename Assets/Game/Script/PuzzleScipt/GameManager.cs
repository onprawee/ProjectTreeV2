using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Sprite[] puzzleImage;
    [SerializeField] public SpriteRenderer spriteRenderer;

    int randomNumber;
    void Start()
    {
        RandomPuzzle();
    }

    public void RandomPuzzle()
    {
        randomNumber = Random.Range(0, 3);
        spriteRenderer.sprite = puzzleImage[randomNumber];
        // Debug.Log(randomNumber);

    }
}
