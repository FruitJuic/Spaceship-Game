using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInteract : MonoBehaviour
{

    public float interactDistance = 5f;
    public GameObject currentTarget = null;
    public List<GameObject> interactables = new List<GameObject>();

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
            currentTarget = candidate;
        }
        else
        {
            currentTarget = null;
        }
    }

    public void RegisterInteractable(GameObject interactable)
    {
        interactables.Add(interactable);
    }
}
