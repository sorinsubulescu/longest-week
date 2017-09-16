using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    // Normal Movements Variables
    private float walkSpeed;
    private float curSpeed;
    private float maxSpeed;

    private Rigidbody2D rigidbody2D;
    // private CharacterStat plStat;

    void Start()
    {
     //   plStat = GetComponent<CharacterStat>();

        walkSpeed = 20;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        curSpeed = walkSpeed;
        maxSpeed = curSpeed;

        // Move senteces
        rigidbody2D.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 0.8f),
                                             Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 0.8f));
    }
}