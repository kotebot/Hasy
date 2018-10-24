using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShermanLibr;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;

    public float Speed;//скорость
    public float forceJump;//сила прыжка
    public Transform groudCheck;//проверка на потолок
    public Transform ceilingCheck;//пол
    public LayerMask whatIsGround;//что есть земля
    [HideInInspector]
    public Vector3 spawnCord;//координаты спавна
    private float force;//сила
    private bool grounded;//стоишь ли на земле
    private Rigidbody2D rb;//ссылка на риджидбоди

    private void Awake()
    {
        instance = this;
        Spawn.UpdatePointSpawn(gameObject);//обновление точки спавна

    }

    void Start () {     
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(!Gravity.InvertGravity)//если физики не инвертна то земля снизу
            grounded =Physics2D.OverlapCircle(groudCheck.position, 0.2f, whatIsGround);
        else // иначе сверху
            grounded = Physics2D.OverlapCircle(ceilingCheck.position, 0.2f, whatIsGround);
        if (Platform.PC && Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.UpArrow))//если это пк то прыжок W
        {
            Jump();
        }
    }

    void FixedUpdate () {
        if (Platform.PC)
        {
            force = Input.GetAxis("Horizontal");//кнопки
        }
        else force = UIManager.instance.joystick.Horizontal;//джойстик
        rb.AddForce(new Vector2(Speed * force,0));//движение
    }

    public void Jump()//прыжок
    {
        if (grounded)//если ты на земле
        {
            AudioManager.instance.jump.Play();//звук
            rb.AddForce(new Vector2(0, forceJump), ForceMode2D.Impulse);//физика
        }
            
    }
}
