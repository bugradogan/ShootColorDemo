using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
   
    public float ballSpeed = 8f;
    private Rigidbody rb;
    private MeshRenderer ball;
    private Shooter shooter;
    private Vector3 dir;
    [HideInInspector] public Color ballColor;
    [HideInInspector] public ShooterColor color;

    // Start is called before the first frame update
    void Start()
    {
        dir = GetComponentInParent<Transform>().forward;
        ball = GetComponent<MeshRenderer>();
        shooter = GetComponentInParent<Shooter>();
        rb = GetComponent<Rigidbody>();

        color = shooter.shooterColor;

        if (shooter.shooterColor == ShooterColor.Red)
            ballColor = ball.material.color = shooter.colors[0];
        else if (shooter.shooterColor == ShooterColor.Green)
            ballColor = ball.material.color = shooter.colors[1];
        else if (shooter.shooterColor == ShooterColor.Blue)
            ballColor = ball.material.color = shooter.colors[2];

        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = dir * ballSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Wall_B")
        {
            dir = Vector3.back;
        }
        else if (other.gameObject.tag == "Wall_L")
        {
            dir = Vector3.left;
        }
        else if (other.gameObject.tag == "Wall_R")
        {
            dir = Vector3.right;
        }
        else if (other.gameObject.tag == "Wall_F")
        {
            dir = Vector3.forward;
        }
    }


}
