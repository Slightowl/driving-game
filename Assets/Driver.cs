using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float destroyDelay = 1f;
    [SerializeField] float steerSpeed = 100f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float slowSpeed = 10f;
    [SerializeField] float boostSpeed = 30f;


    void Update()
    {
        if (gameObject.tag == "Player") {
            float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
            float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            transform.Rotate(0, 0, -steerAmount);
            transform.Translate(0, moveAmount, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Booster") 
        {
            Debug.Log("Booster picked up!");
            moveSpeed = boostSpeed;
            Destroy(other.gameObject, destroyDelay);
        }
        if (other.gameObject.tag == "Bumper") 
        {
            Debug.Log("Bumper picked up!");
            moveSpeed = slowSpeed;
            Destroy(other.gameObject, destroyDelay);
        }
    }
}
