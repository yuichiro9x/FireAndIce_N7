using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;

public class IceCharacter : Character
{

    // Start is called before the first frame update
    void Start()
    {
        SetRigidbody2D(GetComponent<Rigidbody2D>());
        SetInputHorizontalName("HorizontalIce");
    }

    void Update()
    {
        if (Input.GetButtonDown("JumpIce") && !GetIsJumping())
        {
            SetIsJump(true);
        }

        if (GetIsRespawn())
        {
            Respawn();
        }
    }

    void FixedUpdate()
    {
        if (GetIsAlive())
        {
            Movement();
            if (GetIsJump()) Jump();
        }
        else GetRigidbody2D().velocity = Vector3.zero;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Fire")
        {
            if (GetIsAlive())
            {
                OnDeath();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            if (GetIsAlive())
            {
                OnDeath();
            }
        }
    }
}
