using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed;
    public TimeManager TimeManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Intersection"))
        {
            Debug.Log("Intersection");
            TimeManager.SlowMotion();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Intersection"))
        {
            TimeManager.StopSlowMotion();
        }
    }
}
