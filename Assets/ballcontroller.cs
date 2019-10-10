using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballcontroller : MonoBehaviour {

    Rigidbody rb;
    Vector3 move;

    [SerializeField] [Range(1,100)]public float BallSpeed;
    private int vectorY;
    private int vectorX;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

        StartCoroutine(StartDelay(3));
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = move;
	}
    IEnumerator StartDelay(float Delay )
    {
        yield return new WaitForSeconds(Delay);
        LaunchBall();

    }
    void LaunchBall()
    {
        vectorY = Random.Range(0, 2);
        vectorX = Random.Range(0, 2);
        switch (vectorY)
        {
            case 0:
                move.y = 1 * BallSpeed;
                break;
            case 1:
                move.y = -1 * BallSpeed;
                break;

        }
        switch (vectorX)
        {
            case 0:
                move.x = 1 * BallSpeed;
                break;
            case 1:
                move.x = -1 * BallSpeed;
                break;
        }
    }
    void Restart()
    {
        move = Vector3.zero;
        transform.position = Vector3.zero;
        StartCoroutine(StartDelay(3));
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("top"))
        {
            move.y = -1 * BallSpeed;

        }
        if (collision.gameObject.CompareTag("bottom"))
        {
            move.y = 1 * BallSpeed;

        }
        if (collision.gameObject.CompareTag("left") || collision.gameObject.CompareTag("right"))
        {
            Restart();

        }
    }
}
