using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed;
    public TimeManager TimeManager;
    public List<KeyCode> Keys;
    List<KeyCode> randomFour;
    bool intersectionPhase = false;


    // Start is called before the first frame update
    void Start()
    {
        randomFour = new List<KeyCode> { };
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        if (intersectionPhase)
        {
            TurnDirection();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Intersection"))
        {
            intersectionPhase = true;
            KeyBinds();
            Debug.Log("Intersection");
            TimeManager.SlowMotion();
        }
        foreach (var item in randomFour)
        {
            Debug.Log(item);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Intersection"))
        {
            intersectionPhase = false;
            TimeManager.StopSlowMotion();
        }
        randomFour.Clear();
    }

    void KeyBinds()
    {
        while (randomFour.Count<4)
        {
            var index = Random.Range(0, Keys.Count-1);
            if(!randomFour.Contains(Keys[index]))
            {
                randomFour.Add(Keys[index]);
            }
        }
    }

    void TurnDirection()
    {
        if(Input.GetKey(randomFour[0]))
        {
            Debug.Log("111");
        }
        if (Input.GetKey(randomFour[1]))
        {
            Debug.Log("222");
        }
        if (Input.GetKey(randomFour[2]))
        {
            Debug.Log("ww333ww");
        }
        if (Input.GetKey(randomFour[3]))
        {
            Debug.Log("444");
        }
    }
}
