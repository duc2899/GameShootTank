using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 movement = new Vector2(0, 0);
    [SerializeField] float speed = 3f;
    [SerializeField] Transform _camera;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpForce = 520f;
    [SerializeField] float flipDuration = 0.5f; // Thời gian để hoàn thành một vòng lộn

    private bool isFlipping = false;
    [SerializeField] bool isTouchGroud = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = Vector2.zero;
        movement.x = Input.GetAxis("Horizontal") * speed;
        movement.y = rb.velocity.y;

        if (Input.GetKeyDown(KeyCode.Space) && !isFlipping && isTouchGroud)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            StartCoroutine(Flip());
        }
        RaycastHit2D raycastHit2D = Physics2D.Raycast(this.transform.position, Vector2.down, Vector2.down.magnitude);
           Debug.DrawRay(this.transform.position, Vector2.down, Color.red);
        if(raycastHit2D.collider != null)
        {
            Debug.Log(raycastHit2D.collider.name);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x, rb.velocity.y);
    }

    private IEnumerator Flip()
    {
        isFlipping = true;
        isTouchGroud = false;
        float elapsedTime = 0f;
        float startRotation = transform.eulerAngles.z;
        float targetRotation = startRotation - 360f;

        while (elapsedTime < flipDuration)
        {
            float angle = Mathf.Lerp(startRotation, targetRotation, elapsedTime / flipDuration);
            transform.rotation = Quaternion.Euler(0, 0, angle);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = Quaternion.Euler(0, 0, 0); // Đảm bảo xoay tròn hoàn toàn
        isFlipping = false;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(CONSTANT.GroundTag))
            isTouchGroud = true;
    }




}
