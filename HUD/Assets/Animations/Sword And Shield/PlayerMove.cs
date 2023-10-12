using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float speedX;
    float speedZ;
    bool isAttack = false;
    float attackdelay = 1f;

    bool isGraunded = true;
    Vector3 force = new Vector3(0, 300, 0);

    Rigidbody playerRB;
    Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerAnim.SetBool("attack", true);
            isAttack = true;
        }
        if (isAttack && attackdelay > 0)
        {
            attackdelay -= Time.deltaTime;
        }
        else
        {
            isAttack = false;
            attackdelay = 1f;
            playerAnim.SetBool("attack", false); 
        }
    }

    private void FixedUpdate()
    {
        playerAnim.SetBool("run", false);
        if (Input.GetKey(KeyCode.W))
        {
            speedZ = 0.1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            speedZ = -0.1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            speedX = -0.1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            speedX = 0.1f;
        }
        if (Input.GetKey(KeyCode.Space) && isGraunded)
        {
            isGraunded = false;
            playerRB.AddForce(force);
        }

        if (speedX != 0 || speedZ != 0)
        {
            playerAnim.SetBool("run", true);
        }

        transform.Translate(speedX, 0, speedZ);
        speedX = 0;
        speedZ = 0;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGraunded = true;
        }
    }
}
