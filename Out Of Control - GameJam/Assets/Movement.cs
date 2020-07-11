using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Movement : MonoBehaviour
{
    public float movementSpeed;
    public TimeManager TimeManager;
    public List<KeyCode> Keys;
    List<KeyCode> randomFour;
    bool intersectionPhase = false;
    private bool HasTurned = false;
    public TextMeshProUGUI LeftText;
    public TextMeshProUGUI RightText;
    public TextMeshProUGUI UpText;
    private string LeftBinding;
    private string RightBinding;
    private string UpBinding;
    private Vector3 intersectionPos;


    // Start is called before the first frame update
    void Start()
    {
        LeftText = GameObject.Find("Text Left").GetComponent<TextMeshProUGUI>();
        RightText = GameObject.Find("Text Right").GetComponent<TextMeshProUGUI>();
        UpText = GameObject.Find("Text Up").GetComponent<TextMeshProUGUI>();

        randomFour = new List<KeyCode> { };
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        if ((intersectionPhase)&&(!HasTurned))
        {
            TurnDirection();
           
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Intersection"))
        {
            intersectionPos = other.transform.position;
            intersectionPhase = true;
            KeyBinds();
            Debug.Log("Intersection");
            TimeManager.SlowMotion();

            LeftText.text = LeftBinding;
            RightText.text = RightBinding;
            UpText.text = UpBinding;
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
        HasTurned = false;
    }

    void KeyBinds()
    {
        while (randomFour.Count<3)
        {
            var index = Random.Range(0, Keys.Count-1);
            if(!randomFour.Contains(Keys[index]))
            {
                randomFour.Add(Keys[index]);
            }
        }
        LeftBinding = randomFour[0].ToString();
        RightBinding = randomFour[1].ToString();
        UpBinding = randomFour[2].ToString();
    }

    void TurnDirection()
    {
        if(Input.GetKeyDown(randomFour[0]))
        {
            Debug.Log("111");
            transform.Rotate(Vector3.up, -90);
            HasTurned = true;

            TimeManager.StopSlowMotion();
            intersectionPhase = false;
            transform.position = intersectionPos;
        }
        if (Input.GetKey(randomFour[1]))
        {
            Debug.Log("222");

            TimeManager.StopSlowMotion();
            intersectionPhase = false;
            transform.position = intersectionPos;
        }
        if (Input.GetKey(randomFour[2]))
        {
            Debug.Log("ww333ww");
            transform.Rotate(Vector3.up, 90);
            HasTurned = true;

            TimeManager.StopSlowMotion();
            intersectionPhase = false;
            transform.position = intersectionPos;
        }
       
    }
}
