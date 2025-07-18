using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPoint;

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mouseWorldPosition - shotPoint.position).normalized;

            GameObject newBullet = Instantiate(bullet, shotPoint.position, Quaternion.identity);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            newBullet.transform.rotation = Quaternion.Euler(0f, 0f, angle);

            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();

            // rb.linearVelocity = direction * bulletSpeed;
        }
    }
}
