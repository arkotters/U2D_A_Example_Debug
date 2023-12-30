using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    public Collider2D detectedObjs;
    public float viewRadius;
    public LayerMask playerLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D collider=Physics2D.OverlapCircle(transform.position, viewRadius, playerLayerMask);

        if(collider!=null)
        {
            detectedObjs = collider;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, viewRadius);
    }
}


