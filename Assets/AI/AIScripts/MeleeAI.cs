using UnityEngine;

namespace EnemyAI
{

    public class MeleeAI : AIBehaviour
    {
        public float raycastDistance = 3f; // max shooting distance
        public LayerMask hitLayer; // layer which can be hit


        void Start()
        {
            playerChar = GameObject.FindGameObjectWithTag("Player");
        }


        void Update()
        {
            // Move the enemy character towards the player character no pathfinding
            moveEnemy();
            moveAngle(); //to change the enemy character's rotation to face the player character
            raycastShoot();
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
