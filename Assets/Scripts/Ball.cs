using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] PaddleMovement paddle1;
    Vector2 paddleToBallVector;
    bool startGame;
    int bricksremaining;
    float minspeedforpush = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y));
        if (!startGame)
        {
            LockBallToPaddle();
            LaunchBallOnMouseClick();
        }
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) < minspeedforpush)
        {
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity + new Vector2(0f, 1f);
        }
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) < minspeedforpush)
        {
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity + new Vector2(1f, 0f);
        }

    }
    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
    private void LaunchBallOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-2.0f, 2.0f), 15f);
            startGame = true;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (startGame)
        {
            GetComponent<AudioSource>().Play();
            bricksremaining = GameObject.FindGameObjectsWithTag("brick").Length;
            if (bricksremaining == 0)
            {
                int currentScene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentScene + 1);
            }
        }
    }
}
