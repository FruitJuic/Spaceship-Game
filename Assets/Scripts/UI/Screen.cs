using UnityEngine;

public class Screen : MonoBehaviour
{

    public bool isLocking;
    public bool menu;
    public CursorLockMode cursorMode;

    GameObject closingObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activeInteract()
    {
        closingObject.SendMessage("Close");
    }

    public void RegisterCloseObject(GameObject closeObject)
    {
        closingObject = closeObject;
    }
}
