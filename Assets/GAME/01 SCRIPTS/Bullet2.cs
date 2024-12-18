using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : BulletBase
{
    protected override void Boom(GameObject target)
    {
        IGetHit isCanGetHit = target.GetComponent<IGetHit>();
        if (isCanGetHit == null) {
            Destroy(this.gameObject);
            return;
        }
        isCanGetHit.getHit(this._damage);
        this._damage /= 2f;
        this._speed /= 2f;
        if(this._countTarget >= 2)
        {
            Destroy(this.gameObject);
        }
        this._countTarget++;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.Boom(collision.gameObject);
    }
}
