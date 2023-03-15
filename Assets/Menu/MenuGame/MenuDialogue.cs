using UnityEngine;
using UnityEngine.UI;

public class MenuDialogue : MonoBehaviour
{
    public GameObject[] dialoguePage;

    public Button nextButton, previousButton, closeButton;

    private int currentPage = 0;

    void Start()
    {
        currentPage = 0;
        dialoguePage[currentPage].SetActive(true);

    }
    void Update()
    {
        if (currentPage <= 0)
        {
            previousButton.gameObject.SetActive(false);
            // closeButton.gameObject.SetActive(false);
        }
        else
        {
            previousButton.gameObject.SetActive(true);
        }

        if (currentPage >= dialoguePage.Length - 1)
        {
            nextButton.gameObject.SetActive(false);
            closeButton.gameObject.SetActive(true);

        }
        else
        {
            nextButton.gameObject.SetActive(true);
            closeButton.gameObject.SetActive(false);
        }
    }

    public void NextPage()
    {
        dialoguePage[currentPage].SetActive(false);
        currentPage++;
        dialoguePage[currentPage].SetActive(true);
        AudioManager.instance.PlaySFX("Click");
    }
    public void PreviousPage()
    {
        dialoguePage[currentPage].SetActive(false);
        currentPage--;
        dialoguePage[currentPage].SetActive(true);
        AudioManager.instance.PlaySFX("Click");
    }

}
