using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Gravity : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.006674f;

    public static List<Gravity> otherObjectsList;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (otherObjectsList == null)
        {
            otherObjectsList = new List<Gravity>();
        }

        otherObjectsList.Add(this);
    }
    private void FixedUpdate()
    {
        foreach (Gravity obj in otherObjectsList)
        {
            if (obj != this)
            {
                Attract(obj);
            }
        }
    }
    void Attract(Gravity other)
    {
        Rigidbody otherRb = other.rb;

        Vector3 diraction = rb.position - otherRb.position;

        float distance = diraction.magnitude;

        if(distance == 0f)
        {
            return;
        }

        float forceMegnitude = G * (rb.mass * otherRb.mass)/Mathf.Pow(distance, 2);
        Vector3 gravityForce = forceMegnitude * diraction.normalized;

        otherRb.AddForce(gravityForce);
    }
  
}
