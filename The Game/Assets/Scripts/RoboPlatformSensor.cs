using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboPlatformSensor : MonoBehaviour
{
    public bool movingLeft = true;
    public float speed;

    public GameObject enemy_HealthBar;
    public GameObject enemyBody;
    private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Protagonist").GetComponent<Transform>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > 5f)
        {
            enemyBody.transform.Translate(Vector2.left * speed * Time.deltaTime);
            enemy_HealthBar.transform.position = new Vector3(enemyBody.transform.position.x, enemy_HealthBar.transform.position.y, enemy_HealthBar.transform.position.z);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("platform"))
        {
            Debug.Log("hit");
            if (movingLeft == true)
            {
                enemyBody.transform.eulerAngles = new Vector3(0, -180, 0);
                movingLeft = false;
            }
            else
            {
                enemyBody.transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;
            }
        }
    }

}
