using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] Player_State state;

    public GameObject bullet;
    public Transform shotPoint;
    bool allowShooting = true;
    public bool isFacingRight = true;

    private void Start()
    {
        state = GetComponent<Player_State>();
        if (state == null)
            Debug.LogError("Player_State 컴포넌트를 찾을 수 없습니다!");
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput > 0)
            isFacingRight = true;
        else if (moveInput < 0)
            isFacingRight = false;

        Shoot();
    }
    
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.I) && allowShooting)
        {
            if (state == null)
            {
                Debug.Log("state가 null임");
                return;
            }

            Vector2 direction = isFacingRight ? Vector2.right : Vector2.left;

            GameObject newBullet = Instantiate(bullet, shotPoint.position, transform.rotation);
            newBullet.transform.rotation = Quaternion.Euler(0, 0, isFacingRight ? 0 : 180);

            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            rb.linearVelocity = direction * state.shootingSpeed;

            Bullet bulletScript = newBullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.player = this.gameObject;
                bulletScript.state = this.state;
            }

            allowShooting = false;

            Invoke("EnableShooting", state.shootingCooltime);
        }
    }

    void EnableShooting()
    {
        allowShooting = true;
    }
}
