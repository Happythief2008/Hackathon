using UnityEngine;

public class Attack : MonoBehaviour
{
    public float moveSpeed = 5f; public float bulletSpeed = 5f;
    public GameObject bullet;
    public Transform shotPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }
    void Move()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float vt = Input.GetAxisRaw("Vertical");

        Vector3 moveVector = new Vector3(hor, vt).normalized;
        transform.position += moveVector * Time.deltaTime * moveSpeed;
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mouseWorldPosition - shotPoint.position).normalized;

            GameObject newBullet = Instantiate(bullet, shotPoint.position, Quaternion.identity);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            newBullet.transform.rotation = Quaternion.Euler(0f, 0f, angle);

            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();

            rb.linearVelocity = direction * bulletSpeed;
        }
    }
}
