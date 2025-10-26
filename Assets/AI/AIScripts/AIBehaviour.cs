using UnityEngine;

namespace EnemyAI
{


    public class AIBehaviour : MonoBehaviour
    {
        public GameObject playerChar;
        public GameObject enemyChar;
        public float speed;
        public float rotationSpeed;

        void start()
        {
            // Find the player character in the scene
            playerChar = GameObject.FindGameObjectWithTag("Player");
            // Find the enemy character in the scene
            //enemyChar = GameObject.FindGameObjectWithTag("Enemy");
            //speed = 25f; // Set the speed of the enemy character
            //rotationSpeed = 2f; // Set the rotation speed of the enemy character

        }

        void Update()
        {
            // Move the enemy character towards the player character no pathfinding
            moveEnemy();
            moveAngle(); //to change the enemy character's rotation to face the player character

        }
        protected void moveAngle()
        {
            if (playerChar == null)
            {
                Debug.Log("Player not found angle");
                return;
            }
            enemyChar.transform.rotation = Quaternion.Slerp(enemyChar.transform.rotation, Quaternion.LookRotation(playerChar.transform.position - enemyChar.transform.position), rotationSpeed * Time.deltaTime); //rotates the ai to face the player character
            enemyChar.transform.rotation = Quaternion.Euler(0, enemyChar.transform.rotation.eulerAngles.y, 0); // Keep the rotation on the Y axis only
        }
        protected void moveEnemy()
        {
            if (playerChar == null)
            {
                Debug.Log("Player not found move");
                return;
            }
            enemyChar.transform.position = Vector3.MoveTowards(enemyChar.transform.position, playerChar.transform.position, speed * Time.deltaTime); // Moves the enemy character towards the player character

        }
    }
}
