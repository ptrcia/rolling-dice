using System.Collections.Generic;
using UnityEngine;

public class SelectDice : MonoBehaviour
{

    RaycastHit hit;
    Ray ray;
    List<GameObject> targets = new List<GameObject>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Down");
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Dice")
                {
                    if (!targets.Contains(hit.collider.gameObject))
                    {
                        targets.Add(hit.collider.gameObject);
                        hit.collider.gameObject.GetComponent<Outline>().enabled = true;
                        Debug.Log("Added " + hit.collider.gameObject.name + " to targets");
                    }
                    else
                    {
                        targets.Remove(hit.collider.gameObject);
                        hit.collider.gameObject.GetComponent<Outline>().enabled = false;
                        Debug.Log("Removed " + hit.collider.gameObject.name + " from targets");
                    }
                }
            }
        }
    }


    public List<GameObject> GetTargets() { return targets; }
}

