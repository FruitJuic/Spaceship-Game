using UnityEngine;

public class ShipTerminal : MonoBehaviour
{
    public GameObject SCREEN;
    public ScreenManager screenManager;

    public Vector3 cameraPosition;
    public Vector3 cameraRotation;

    public GameObject player;
    public float lerpSpeed = 1f;
    bool movingCamera = false;
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
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, transform.position + cameraPosition, Time.deltaTime * lerpSpeed);
            Camera.main.transform.eulerAngles = Vector3.Lerp(Camera.main.transform.eulerAngles, cameraRotation, Time.deltaTime * lerpSpeed);

            if((Camera.main.transform.position - (transform.position + cameraPosition)).magnitude < magnitudeMargin)
            {
                movingCamera = false;
                screenManager.ActivateScreen(SCREEN);
            }
        }
    }

    public void interact()
    {
        player.GetComponent<PlayerMovement>().inLockingMenu = true;
        movingCamera = true;
        //screenManager.ActivateScreen(SCREEN);
    }
}
