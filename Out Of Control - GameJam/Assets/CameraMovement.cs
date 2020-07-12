using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform objectToFollowTransform;
    public Vector3 offset;
    public float followSpeed = 10;
    public float lookSpeed = 10;
    void Start()
    {
        objectToFollowTransform = GameObject.Find("Playa").GetComponent<Transform>();
    }

    void LateUpdate()
    {
        LookAtTarget();
        MoveToTarget();
    }

    public void LookAtTarget()
    {
        Vector3 lookDirection = objectToFollowTransform.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, lookSpeed * Time.deltaTime);
    }

    public void MoveToTarget()
    {
        Vector3 targetPos = objectToFollowTransform.position + objectToFollowTransform.forward * offset.z +
                                                               objectToFollowTransform.right * offset.x +
                                                               objectToFollowTransform.up * offset.y;
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
    }
}