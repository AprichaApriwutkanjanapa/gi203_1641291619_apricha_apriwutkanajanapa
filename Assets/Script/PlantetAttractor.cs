using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantetAttractor : MonoBehaviour
{
    public Rigidbody rb;
    private const float G = 6.67f;
    public static List<PlantetAttractor> pAttractors;


    void AttractorFormular(PlantetAttractor other)
    {
        //F = G* (m1+m2)/d^2 ;

        Rigidbody rb0ther = other.rb;

        Vector3 direction = rb.position - rb0ther.position;

        float distance = direction.magnitude; //magnitude to make number intergrate
        
        //F = G* (m1+m2)/d^2 ;
        float forceMagnitude = G* (rb.mass * rb0ther.mass) / Mathf.Pow(distance, 2); 


        Vector3 forceDir = direction.normalized * forceMagnitude;

        rb0ther.AddForce(forceDir);
    }

    void FixedUpdate()
    {
        foreach (var attractor in pAttractors)         
        {
            if (attractor != this)
            {
                AttractorFormular (attractor);
            }
        }
    }

    private void OnEnable()
    {
        if (pAttractors == null) 
        {
            pAttractors = new List<PlantetAttractor>();
        }

        pAttractors.Add(this);

    }

}
