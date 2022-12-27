using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private states State
    {
        get { return (states)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        State = states.test_animation;
        if (Input.GetButton("Horizontal"))
            RunRL();
        if (Input.GetButton("Vertical"))
            RunUD();
    }

    private void RunRL()
    {
        State = states.run;

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        sprite.flipX = dir.x < 0.0f;
    }

    private void RunUD()
    {
        State = states.run;

        Vector3 dir = transform.up * Input.GetAxis("Vertical");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    }
}

public enum states
{
    test_animation,
    run
}
