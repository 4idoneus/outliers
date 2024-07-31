using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    public Collider2D coll;
    public List<Collider2D> detectedObjects = new List<Collider2D>();

    // Start is called before the first frame update
    void Start()
    {
        // Collider2D'yi GetComponent ile alýyoruz.
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            detectedObjects.Add(collider);
            Debug.Log("Player Detected: " + collider.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            detectedObjects.Remove(collider);
            Debug.Log("Player Lost: " + collider.name);
        }
    }
}
