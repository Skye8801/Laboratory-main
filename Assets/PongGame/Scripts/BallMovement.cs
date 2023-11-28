using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{

    [SerializeField] private float initialSpeed = 10f;
    [SerializeField] private float speedIncrease = 0.25f;
    [SerializeField] private Text playerScore;
    [SerializeField] private Text AIScore;


    private int hitCounter;
    private Rigidbody2D rb;

    float xDirection;
    float yDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke(nameof(StartBall), 2f);
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, initialSpeed + (speedIncrease * hitCounter));
    }

    private void StartBall()
    {
        rb.velocity = new Vector2(1, 0) * (initialSpeed + speedIncrease * hitCounter);
    }

    private void ResetBall()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
        hitCounter = 0;
        Invoke("StartBall", 2f);
    }

    private void PlayerBounce(Transform myObject)
    {
       
            hitCounter++;

            Vector2 ballPos = transform.position;
            Vector2 PlayerPos = myObject.position;

       
            if(transform.position.x < 0)
            {
                xDirection = -1f;
            }
            else
            {
                xDirection = 1f;
            }
            xDirection = (ballPos.y - PlayerPos.y) / myObject.GetComponent<Collider2D>().bounds.size.y;

            if(yDirection == 0f)
            {
                yDirection = 0.05f;
            }

            Vector2 direction = new Vector2(xDirection, yDirection).normalized * (initialSpeed + (speedIncrease * hitCounter));

            rb.velocity = direction;

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player" || collision.transform.tag == "AI")
        {
            PlayerBounce(collision.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Finish")
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * -1);
        }
        else if(transform.position.x > 0f)
        {
            Debug.Log("Mål");
            ResetBall();
            playerScore.text = (int.Parse(playerScore.text) + 1).ToString();
        }
        else if(transform.position.x < 0f)
        {
            Debug.Log("Mål");

            ResetBall();
            AIScore.text = (int.Parse(AIScore.text) + 1).ToString();
        }
    }
}
