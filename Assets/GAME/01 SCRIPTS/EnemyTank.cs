using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class EnemyTank : MonoBehaviour, IGetHit
{
    [SerializeField] float _hp = 100;
    [SerializeField] float _amor = 5;
    [SerializeField] float _speed;
    [SerializeField] LayerMask _layerMask;
    [SerializeField] float circleTargetRadius;
    [SerializeField] GameObject bulletPrefab; // Prefab viên đạn
    [SerializeField] Transform firePoint; // Vị trí bắn đạn
    [SerializeField] float bulletSpeed = 10f; // Tốc độ viên đạn
    [SerializeField] float shootCooldown = 2f; // Thời gian giữa các lần bắn

    private Vector2 movement;
    private Transform target;
    private Rigidbody2D rigi;
    private float nextShootTime = 0f; // Thời gian cho lần bắn tiếp theo

    void Start()
    {
        rigi = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (detectPlayer())
        {
            target = null; // Không phát hiện Player
        }
        else
        {
            if (Time.time >= nextShootTime)
            {
                Shoot(); // Bắn đạn
                nextShootTime = Time.time + shootCooldown; // Cập nhật thời gian bắn tiếp theo
            }
        }

        chasePlayer();
        circleDetectPlayer();
    }

    void FixedUpdate()
    {
        rigi.velocity = transform.up * _speed * movement;
    }

    void chasePlayer()
    {
        if (target == null)
        {
            movement = Vector2.zero; // Enemy không di chuyển nếu không có mục tiêu
            return;
        }

        // Tính toán hướng từ Enemy tới Player
        Vector2 dir = target.position - transform.position;

        // Tính góc quay dựa trên hướng
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Cập nhật hướng di chuyển (chuẩn hóa vector để có độ dài bằng 1)
        movement = dir.normalized;
    }

    bool detectPlayer()
    {
        if (target == null) return true;

        Vector2 direction = (target.position - transform.position).normalized;
        float distance = Vector2.Distance(transform.position, target.position);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance);

        Debug.DrawLine(transform.position, transform.position + (Vector3)direction * distance, Color.white);

        if (hit.collider == null || !hit.collider.CompareTag(CONSTANT.PlayerLayerTag))
        {
            return true; // Không phát hiện Player
        }

        return false; // Phát hiện Player
    }

    void circleDetectPlayer()
    {
        Collider2D[] collidersHit = Physics2D.OverlapCircleAll(transform.position, circleTargetRadius, _layerMask);

        foreach (Collider2D col in collidersHit)
        {
            if (col.gameObject.GetInstanceID() == gameObject.GetInstanceID()) continue;

            target = col.transform;
        }

        if (target != null)
        {
            if (Vector2.Distance(target.position, transform.position) > circleTargetRadius)
            {
                target = null;
            }
        }
    }

    void Shoot()
    {
        if (firePoint == null || bulletPrefab == null || target == null) return;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 direction = (target.position - firePoint.position).normalized;
            rb.velocity = direction * bulletSpeed;
        }

        Destroy(bullet, 5f); // Huỷ viên đạn sau 5 giây
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, circleTargetRadius);
    }

    public void getHit(float damage)
    {
        if (damage - _amor > 0)
        {
            this._hp -= damage - _amor;
        }

        if (this._hp < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
