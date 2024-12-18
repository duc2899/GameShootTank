using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject bulletPrefab; // Prefab viên đạn
    public Transform firePoint;     // Vị trí bắn đạn (đầu nòng súng)
    public float bulletSpeed = 10f; // Tốc độ viên đạn
    public float fireRate = 2f;     // Tốc độ bắn (giây)

    private float nextFireTime = 3f; // Thời gian cho lần bắn tiếp theo
    Rigidbody2D rigi;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            fire(); // Bắn đạn
            nextFireTime = Time.time + 1f / fireRate; // Tính thời gian lần bắn tiếp theo
        }
    }

    void fire()
    {
        // Tạo viên đạn tại vị trí firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Lấy Rigidbody2D của viên đạn để áp dụng lực
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.right * bulletSpeed; // Đẩy viên đạn theo hướng của firePoint
        }

        // Tuỳ chọn: Huỷ viên đạn sau một khoảng thời gian (nếu không muốn nó tồn tại mãi)
        Destroy(bullet, 5f); // Viên đạn sẽ tự huỷ sau 5 giây
    }
}
