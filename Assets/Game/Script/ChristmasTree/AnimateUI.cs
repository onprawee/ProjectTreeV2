using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimateUI : MonoBehaviour
{
    public Image image;
    public float speed = 0.3f;
    public Sprite[] sprites;


    private void Start()
    {
        StartCoroutine(Animate());
    }
    public void Menu_Game()
    {
        AudioManager.instance.PlaySFX("Click");
        SceneManager.LoadScene("Menu_Game");
        StopCoroutine(Animate());
    }
    IEnumerator Animate()
    {
        while (true)
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                image.sprite = sprites[i];
                yield return new WaitForSeconds(speed);
            }
        }
    }


}
