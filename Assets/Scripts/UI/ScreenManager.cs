using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public GameObject NORMAL;
    public GameObject[] screens;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CloseScreen();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateScreen(GameObject targetScreen)
    {
        foreach(GameObject screen in screens)
        {
            screen.SetActive(false);
        }

        targetScreen.SetActive(true);
    }

    public void CloseScreen()
    {
        foreach(GameObject screen in screens)
        {
            screen.SetActive(false);
        }

        NORMAL.SetActive(true);
    }
}
