using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyAI
{
    public class RangedAI : AIMovement
    {
        public float raycastDistance = 10f; // max shooting distance
        public LayerMask hitLayer; // layer which can be hit
        // Start is called before the first frame update
        void Start()
        {
            // Find the player character in the scene
            playerChar = GameObject.FindGameObjectWithTag("Player");
            
        }

        // Update is called once per frame
        void Update()
        {
            // Move the enemy character towards the player character no pathfinding
            moveEnemy();
            moveAngle(); //to change the enemy character's rotation to face the player character
            Hold();
            raycastShoot();
        }
        void Hold()
        {
            if (Vector3.Distance(playerChar.transform.position, enemyChar.transform.position) < 10f)
            {
                // If the player is in 10 stop
                speed = 0f;
            }
            else
            {
                // if player is further than 10 keep moving
                speed = 3f; 
            }
        }
        void raycastShoot()
        {
            Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.red);

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, hitLayer))
            {
                if (hit.transform.CompareTag("Player")) // Check if the hit object is tagged as "Player"
                {
                    Debug.Log("Enemy hit you");
                    //moves the Player randomly
                    hit.collider.transform.position = new Vector3(UnityEngine.Random.Range(-150, 150), 2, UnityEngine.Random.Range(-150, 150));
                }

            }
        }
    }
}
