using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] Transform TargetTransform;
    [SerializeField] float damp = 0.5f;
    Vector3 offset;
    Vector3 refVelocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        offset = TargetTransform.position - transform.position;
        transform.position = TargetTransform.position - offset;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 wanted = TargetTransform.position - offset;
        transform.position = Vector3.SmoothDamp(transform.position, wanted, ref refVelocity, damp);
    }
}
