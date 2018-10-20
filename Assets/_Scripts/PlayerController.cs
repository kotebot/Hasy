using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShermanLibr;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;

    public float Speed;
    public float forceJump;
    public Transform groudCheck;
    public Transform ceilingCheck;
    public LayerMask whatIsGround;
    [HideInInspector]
    public Vector3 spawnCord;
    private float force;
    private bool grounded;
    private Rigidbody2D rb;

    private void Awake()
    {
        instance = this;
        Spawn.UpdatePointSpawn(gameObject);

    }

    void Start () {     
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(!Gravity.InvertGravity)
            grounded =Physics2D.OverlapCircle(groudCheck.position, 0.2f, whatIsGround);
        else
            grounded = Physics2D.OverlapCircle(ceilingCheck.position, 0.2f, whatIsGround);
        if (Platform.PC && Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
    }

    void FixedUpdate () {
        if (Platform.PC)
        {
            force = Input.GetAxis("Horizontal");
        }
        else force = UIManager.instance.joystick.Horizontal;
        rb.AddForce(new Vector2(Speed * force,0));
    }

    public void Jump()
    {
        if (grounded)
        {
            AudioManager.instance.jump.Play();
            rb.AddForce(new Vector2(0, forceJump), ForceMode2D.Impulse);
        }
            
    }
}
