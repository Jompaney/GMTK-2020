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
    public Animator anim;
    public float damping;

    public float fadeTime;
    float x;


    void Start()
    {
        x = movementSpeed;
        randomFour = new List<KeyCode> { };

        LeftText = GameObject.Find("Text Left").GetComponent<TextMeshProUGUI>();
        RightText = GameObject.Find("Text Right").GetComponent<TextMeshProUGUI>();
        UpText = GameObject.Find("Text Up").GetComponent<TextMeshProUGUI>();

    }

    void Update()
    {
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        if ((intersectionPhase) && (!HasTurned))
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
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Intersection"))
        {
            intersectionPhase = false;
            TimeManager.StopSlowMotion();
        }

        LeftText.text = "";
        RightText.text = "";
        UpText.text = "";

        randomFour.Clear();
        HasTurned = false;
    }

    void KeyBinds()
    {
        while (randomFour.Count < 3)
        {
            var index = Random.Range(0, Keys.Count - 1);
            if (!randomFour.Contains(Keys[index]))
            {
                randomFour.Add(Keys[index]);
            }
        }
        LeftBinding = randomFour[0].ToString();
        RightBinding = randomFour[2].ToString();
        UpBinding = randomFour[1].ToString();
    }

    void TurnDirection()
    {
        if (Input.GetKeyDown(randomFour[0]))
        {
            Debug.Log("111");
            //anim.SetTrigger("Left");
            HasTurned = true;
            transform.Rotate(Vector3.up, -90);
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
            //anim.SetTrigger("Right");
            transform.Rotate(Vector3.up, 90);
            HasTurned = true;

            TimeManager.StopSlowMotion();
            intersectionPhase = false;
            transform.position = intersectionPos;
        }

    }

    IEnumerator RotateLeft()
    {
        Debug.Log("Left");
        for (float i = 0.01f; i < fadeTime; i+=0.1f)
        {
            var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, 90, transform.eulerAngles.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, i/fadeTime);
            yield return null;
        }
    }
    IEnumerator RotateRight()
    {
        Debug.Log("Right");
        for (float i = 0.01f; i < fadeTime; i += 0.1f)
        {
            var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, -90, transform.eulerAngles.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, i / fadeTime);
            yield return null;
        }
    }
}
