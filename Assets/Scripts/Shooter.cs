using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    
    public ShooterColor shooterColor;
    public Color[] colors = { Color.red, Color.green, Color.blue};
    public Transform shooterStartPoint;
    public GameObject ballPrefab;
   
    public MeshRenderer shooterMat;

    private void Awake()
    {
        
        if(shooterColor == ShooterColor.Red)
            shooterMat.material.color = colors[0];
        else if(shooterColor == ShooterColor.Green)
            shooterMat.material.color = colors[1];
        else if (shooterColor == ShooterColor.Blue)
            shooterMat.material.color = colors[2];

    }   

    public void Shoot()
    {        
        var ball = Instantiate(ballPrefab, shooterStartPoint.position, shooterStartPoint.rotation);        
        ball.transform.SetParent(transform);      
    }
}
public enum ShooterColor
{
    Red,
    Green,
    Blue
}