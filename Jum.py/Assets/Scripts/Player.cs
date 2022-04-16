using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody rb;

    private bool isGrounded;

    public int score;
    public UI ui;

    public void Awake()
    {
        ui.SetScoreText(score);
    }
    // Update is called once per frame
    void Update()
    {
        //Detecting inputs for horizontal movement
        float x = Input.GetAxis("Horizontal");

        //Detecting inputs for Vertical movement
        float z = Input.GetAxis("Vertical");

        rb.velocity = new Vector3 (x * moveSpeed, rb.velocity.y, z * moveSpeed);

        // copy velocity
        Vector3 tempVal = rb.velocity;
        tempVal.y = 0;

        // if we're moving, rotate to face our moving direction
        if (tempVal.x != 0 || tempVal.z != 0)
        {
            transform.forward = tempVal;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // ForceMode.Force = Gradual Force, Eg: Push a car
            // ForceMode.Impulse = Instant Velocity, Eg: Hitting golf ball
            isGrounded = false;
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
        }

        if (transform.position.y < -10)
        {
            GameOver();
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal == Vector3.up)
        {
            isGrounded = true;
        }
    }

    public void AddScore(int amountScore)
    {
        score += amountScore;
        ui.SetScoreText(score);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
