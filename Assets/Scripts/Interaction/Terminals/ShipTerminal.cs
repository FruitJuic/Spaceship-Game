using UnityEngine;

public class ShipTerminal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteract>().RegisterInteractable(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interact()
    {
        Debug.Log("Ship Terminal Opened");
    }
}
