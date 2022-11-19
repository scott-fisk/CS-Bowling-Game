using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public Rigidbody ballPrefab;
    public float shootSpeed = 300;

    private Animator arrowAnim;

    // Start is called before the first frame update
    void Start()
    {
        arrowAnim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            arrowAnim.enabled = false;
            shootBall();
        }
    }

    void shootBall()
    {
        var projectile = Instantiate(ballPrefab, transform.position, transform.rotation);
        projectile.velocity = -transform.forward * shootSpeed;
    }

}

