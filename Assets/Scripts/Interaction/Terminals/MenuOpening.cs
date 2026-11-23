using UnityEngine;

public class MenuOpening : MonoBehaviour
{
    public Screen SCREEN;
    public ScreenManager screenManager;

    public Vector3 cameraPosition;
    public Vector3 cameraRotation;

    Vector3 originalPosition;
    Vector3 originalRotation;

    public GameObject player;
    public float lerpSpeed = 1f;
    bool movingCamera = false;
    bool close = false;
    public float magnitudeMargin = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Awake()
    {
        player.GetComponent<PlayerInteract>().RegisterInteractable(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = Vector2.Lerp(transform.position, end.position, Time.deltaTime); EXAMPLE LERP
        if(movingCamera)
        {
            if(!close)
            {
                Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, transform.position + cameraPosition, Time.deltaTime * lerpSpeed);
                Camera.main.transform.eulerAngles = Vector3.Lerp(Camera.main.transform.eulerAngles, cameraRotation, Time.deltaTime * lerpSpeed);

                if((Camera.main.transform.position - (transform.position + cameraPosition)).magnitude < magnitudeMargin)
                {
                    movingCamera = false;
                    screenManager.ActivateScreen(SCREEN);
                }
            }
            else
            {
                Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, originalPosition, Time.deltaTime * lerpSpeed);
                Camera.main.transform.eulerAngles = Vector3.Lerp(Camera.main.transform.eulerAngles, originalRotation, Time.deltaTime * lerpSpeed * 2);

                if((Camera.main.transform.position - originalPosition).magnitude < magnitudeMargin)
                {
                    movingCamera = false;
                    player.GetComponent<PlayerMovement>().inLockingMenu = false;
                }
            }
        }
    }

    public void interact()
    {
        player.GetComponent<PlayerMovement>().inLockingMenu = SCREEN.isLocking;
        originalPosition = Camera.main.transform.position;
        originalRotation = Camera.main.transform.eulerAngles;
        close = false;
        movingCamera = true;
        SCREEN.RegisterCloseObject(gameObject);
    }

    public void Close()
    {
        screenManager.CloseScreen();
        close = true;
        movingCamera = true;
    }
}
