using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBase: MonoBehaviour
{
   [SerializeField] protected float _speed, _damage, _lifeTime;
    protected Vector2 _movement = Vector2.zero;
    protected Rigidbody2D _rb;
    protected int _countTarget;

    public void Init(float speed, float damage, float lifeTime, Vector2 movement)
    {
        this._speed = speed;
        this._damage = damage;
        this._lifeTime = lifeTime;
        this._movement = movement;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _movement * _speed;

    }
    protected abstract void Boom(GameObject target);
}
