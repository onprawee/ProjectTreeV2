using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimation : MonoBehaviour
{
    public Sprite[] images;
    private float speed = 0.3f;

    public Image image;

    void Start()
    {
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        while (true)
        {
            for (int i = 0; i < images.Length; i++)
            {
                image.sprite = images[i];
                yield return new WaitForSeconds(speed);
            }
        }
    }
}
