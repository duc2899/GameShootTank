using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    PlayerTank _player;
    [SerializeField] float _bulletSpeed, _bulletDamge, _bulletLifeTime, _atackSpeed; // Tốc độ viên đạn
    [SerializeField] BulletBase _bullet;
    private float _lastTimeFire = -Mathf.Infinity;

    public void Init(PlayerTank player)
    {
        this._player = player;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator CountDownCoroutine(BulletBase bullet)
    {
        yield return new WaitForSeconds(_bulletLifeTime);
        if (bullet != null)
        {
            Destroy(bullet.gameObject);
        }
    }

    public void fire()
    {
        if (Time.time >= _atackSpeed + _lastTimeFire)
        {
            _lastTimeFire = Time.time;
            BulletBase g = Instantiate<BulletBase>(_bullet, this.transform.position, Quaternion.identity);
            g.GetComponent<BulletBase>().Init(_bulletSpeed, _bulletDamge, _bulletLifeTime, _player.transform.up);
            StartCoroutine(CountDownCoroutine(g));
        }
    }

    public void changeBullet(BulletBase currentBullet)
    {
        this._bullet = currentBullet;
    }

}
