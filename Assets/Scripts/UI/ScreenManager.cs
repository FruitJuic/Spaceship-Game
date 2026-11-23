using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public Screen NORMAL;
    public Screen[] screens;

    public Screen activeScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CloseScreen();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateScreen(Screen targetScreen)
    {
        foreach(Screen screen in screens)
        {
            screen.gameObject.SetActive(false);
        }

        targetScreen.gameObject.SetActive(true);

        Cursor.lockState = targetScreen.cursorMode;
        activeScreen = targetScreen;
    }

    public void CloseScreen()
    {
        ActivateScreen(NORMAL);
    }
}
