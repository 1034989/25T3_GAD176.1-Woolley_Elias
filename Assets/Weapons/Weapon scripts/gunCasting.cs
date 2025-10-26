using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunCasting : MonoBehaviour
{
    public float raycastDistance = 100f; // max shooting distance
    public LayerMask hitLayer; // layer which can be hit
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button to shoot
        {
            raycastShoot();
        }
    }
    void raycastShoot()
    {
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.red);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, hitLayer))
        {
            if (hit.transform.CompareTag("Enemy")) // Check if the hit object is tagged as "Enemy"
            {
                Debug.Log("Hit an enemy: " + hit.collider.name);
                //moves the enemy to a specific position
                hit.collider.transform.position = new Vector3(UnityEngine.Random.Range(-150, 150), 2, UnityEngine.Random.Range(-150, 150));
            }
            
        }
    }
}
