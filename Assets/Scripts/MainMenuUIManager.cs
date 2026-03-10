using UnityEngine;

public class MainMenuUIManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private GameObject levelSelectMenu;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject audioMenu; 

    public void OpenLevelSelectMenu()
    {
        levelSelectMenu.SetActive(true);
        mainMenu.SetActive(false);
        audioMenu.SetActive(false);
    }

    public void OpenMainMenu() 
    {
        mainMenu.SetActive(true);
        levelSelectMenu.SetActive(false); 
        audioMenu.SetActive(false);
    }

    public void OpenAudioMenu()
    {
        audioMenu.SetActive(true);
        levelSelectMenu.SetActive(false);
        mainMenu.SetActive(false);
    }
}
