using UnityEngine;

public class Bullet : BulletBase
{
    protected override void Boom(GameObject target)
    {
        IGetHit isCanGetHit = target.GetComponent<IGetHit>();
        if (isCanGetHit != null)
        {
            isCanGetHit.getHit(this._damage);
        }

        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       this.Boom(collision.gameObject);
    }
}
