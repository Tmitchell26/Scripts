using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace SAE
{
    public class PlayerMovement : MonoBehaviour
    {
        private float xVel = 0;
        private float yVel = 0;
        private float zVel = 0;

        [Header("Bike Settings")]
        public float speed = 5f;
        public Rigidbody rb;
        public GameObject bikemodel;
        public int playerCode;
        
        [Header("Angle Directions")]
        public int leftMoveAngle = 0;
        public int rightMoveAngle = 0;
        public int upMoveAngle = 0;
        public int downMoveAngle = 0;

        [Header("Speed Boost")]
        public float currentSpeed;
        public float speedTimer = 10f;
        public float boost = 3f;

        [Header("Shield Boost")]
        public GameObject shieldObject;
        public int health = 1;
        public int shieldHP = 1;
        public int currentHealth;
        public float shieldTimer = 10f;


        [Header("Walls")]
        public GameObject wallPrefab;
        private Collider wall;
        private Vector3 lastWallEnd;

        private List<GameObject> wallList;

        public enum Directions { none, up, right, down, left };
         public Directions lastDir;

        // Update is called once per frame
        void Start()
        {
            shieldObject.SetActive(false);
            currentHealth = health;
            currentSpeed = speed;
            wallList = new List<GameObject>();
            spawnWall();
            lastDir = Directions.none;

        }

        void Update()
        {
            fitColliderBetween(wall, lastWallEnd, transform.position);

            if (Input.GetKeyDown("r"))
            {
                SceneManager.LoadScene(1);
            }
        }

        public void left()
        {
            zVel = 0;
            xVel = -currentSpeed;
            rb.angularVelocity = new Vector3(0, -2, 0);
            bikemodel.GetComponent<Transform>().eulerAngles = new Vector3(0, leftMoveAngle, 0);
            //spawnWall();
            //fitColliderBetween(wall, lastWallEnd, transform.position);
            StartCoroutine(stopRotation());
            rb.velocity = new Vector3(xVel, yVel, zVel);
            lastDir = Directions.left;
        }

        public void right()
        {
            zVel = 0;
            xVel = currentSpeed;
            rb.angularVelocity = new Vector3(0, -2, 0);
            bikemodel.GetComponent<Transform>().eulerAngles = new Vector3(0, rightMoveAngle, 0);
            //spawnWall();
            //fitColliderBetween(wall, lastWallEnd, transform.position);
            StartCoroutine(stopRotation());
            rb.velocity = new Vector3(xVel, yVel, zVel);
            lastDir = Directions.right;
        }

         public void up()
        {
            zVel = currentSpeed;
            xVel = 0;
            rb.angularVelocity = new Vector3(0, -2, 0);
            bikemodel.GetComponent<Transform>().eulerAngles = new Vector3(0, upMoveAngle, 0);
            //spawnWall();
            //fitColliderBetween(wall, lastWallEnd, transform.position);
            StartCoroutine(stopRotation());
            rb.velocity = new Vector3(xVel, yVel, zVel);
            lastDir = Directions.up;
        }

        public void down()
        {
            zVel = -currentSpeed;
            xVel = 0;
            rb.angularVelocity = new Vector3(0, -2, 0);
            bikemodel.GetComponent<Transform>().eulerAngles = new Vector3(0, downMoveAngle, 0);
            //spawnWall();
            //fitColliderBetween(wall, lastWallEnd, transform.position);
            StartCoroutine(stopRotation());
            rb.velocity = new Vector3(xVel, yVel, zVel);
            lastDir = Directions.down;
        }

        public void speedBooster()
        {
            StartCoroutine(speedBoost()); 
        }

        IEnumerator speedBoost()
        {
            currentSpeed = speed + boost;
            speedTimer = 10f;
            while(speedTimer > 0)
            {
                speedTimer -= Time.deltaTime;
                yield return null;
            }
            
            currentSpeed = speed;
        }

        public void shield()
        {
            StartCoroutine(shields());
        }

        IEnumerator shields()
        {
            currentHealth = health + shieldHP;
            shieldTimer = 10f;
            shieldObject.SetActive(true);
            while (shieldTimer > 0)
            {
                shieldTimer -= Time.deltaTime;
                yield return null;
            }

            shieldObject.SetActive(false);
            currentHealth = health;
        }


        IEnumerator stopRotation()
        {
            yield return new WaitForSeconds(.0f);
            rb.angularVelocity = new Vector3(0, 0, 0);
            GetComponent<Transform>().eulerAngles = new Vector3(0, -90, 0);
        }

        public void spawnWall()
        {
            // save last wall's position 
            lastWallEnd = transform.position;

            //spawn in a new light wall 
            GameObject w = Instantiate(wallPrefab, transform.localPosition, Quaternion.identity);
            wall = w.GetComponent<Collider>();

            wallList.Add(w);
        }

        void fitColliderBetween(Collider co, Vector3 a, Vector3 b)
        {
            // Calculate the Center Position
            co.transform.position = a + (b - a) * 0.5f;

            // Scale it (horizontally or vertically)
            float dist = Vector3.Distance(a, b);
            if (a.x != b.x)
            {
                co.transform.localScale = new Vector3(dist + 0.3f, 0.5f, 0.3f);
            }
            else
            {
                co.transform.localScale = new Vector3(0.3f, 0.5f, dist + 0.3f);
            }
        }

        private void Dying()
        {
            if (currentHealth <= 0)
            {
                foreach (GameObject wallInList in wallList)
                {
                    Destroy(wallInList);
                }
                Destroy(this.gameObject);
                //GetComponent<RoundManager>().playerList.Remove(this.gameObject);  //GetComponent<RoundManager>().playerList.Remove(GetComponent<RoundManager>().playerList[playerCode - 1]); //playerList[playerCode - 1]      
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Wall")
            {
                currentHealth = currentHealth - 2;
                Dying();
            }

            if (other.gameObject.tag == "Player")
            {
                currentHealth = currentHealth - 1;
                Dying();   
            }

            if (other.gameObject.tag == "Trail")
            {
                if (other.gameObject.GetComponent<TrailColours>().trailCode != playerCode)
                {
                    currentHealth = currentHealth - 1;
                    Dying();
                }
            }
        }
    }
}
