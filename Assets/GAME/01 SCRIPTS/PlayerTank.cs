using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerTank : MonoBehaviour, IGetHit
{
    [SerializeField] float _hp = 100;
    [SerializeField] float _amor = 10;
    [SerializeField] float _speed;
    [SerializeField] GunController _gun;
    Vector2 movement = Vector2.zero;
    Rigidbody2D rb;
    float rotationAngle = 0f;
    // Start is called before the first frame update

    public void Init()
    {
        _gun.Init(this);
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        if (Input.GetMouseButtonDown(0))
        {
            _gun.fire();
        }

    }


    private void FixedUpdate()
    {
        rb.velocity = movement;

    }

    private void RotatePlayer()
    {
        movement = Vector2.zero;

        float vertivalInput = Input.GetAxis("Vertical");
        if (math.abs(vertivalInput) > 0.01f)
        {
            movement = transform.up * vertivalInput * _speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rotationAngle += 100f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rotationAngle -= 100f * Time.deltaTime;
        }
        transform.rotation = Quaternion.Euler(0, 0, rotationAngle);
        RaycastHit2D raycastHit2D = Physics2D.Raycast(this.transform.position, movement, movement.magnitude);
    }

    public void getHit(float damage)
    {
        if(damage - _amor > 0)
        {
            this._hp -= damage - _amor;
        }

        if(this._hp < 0)
        {
            Debug.Log("Player is dead!!");
        }
    }
}