using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerInteract : MonoBehaviour
{

    public float interactDistance = 5f;
    public GameObject currentTarget = null;
    public List<GameObject> interactables = new List<GameObject>();

    private void OnInteract(InputValue inputValue)
    {
        if(currentTarget != null)
        {
            currentTarget.SendMessage("interact");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetTarget();
        
    }

    private void GetTarget()
    {

        RaycastHit hit;

        // if raycast hits, it checks if it hit an object with the tag Player
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactDistance)     &&
                    interactables.Contains(hit.collider.gameObject))
        {
            SetTarget(hit.collider.gameObject);
            return;
        }


        GameObject candidate = null;
        float currentClosest = 2 * interactDistance;

        foreach(GameObject interactable in interactables)
        {
            float distance = (interactable.transform.position - transform.position).magnitude;
            if(distance < currentClosest)
            {
                currentClosest = distance;
                candidate = interactable;
            }
        }

        if(currentClosest < interactDistance)
        {
            SetTarget(candidate);
        }
        else
        {
            SetTarget(null);
        }
    }

    public void RegisterInteractable(GameObject interactable)
    {
        interactables.Add(interactable);
    }

    void SetTarget(GameObject target)
    {
        // Disable old target text if !null
        currentTarget = target;
        // Enable new target text if !null
    }
}
