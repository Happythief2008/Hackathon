using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    [SerializeField] Player_State state;

    public GameObject bullet;
    public Transform shotPoint;
    bool allowShooting = true;
    public bool isFacingRight = true;

    Animator animator;

    private void Start()
    {
        state = FindObjectOfType<Player_State>();
        if (state == null)
            Debug.LogError("Player_State 컴포넌트를 찾을 수 없습니다!");

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput > 0)
            isFacingRight = true;
        else if (moveInput < 0)
            isFacingRight = false;

        if (Input.GetKeyDown(KeyCode.I) && allowShooting)
        {
            StartCoroutine(ShootWithDelay(0.5f));
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
            }

            allowShooting = false;

        }
    }

    IEnumerator ShootWithDelay(float delay)
    {
        allowShooting = false;
        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(delay);

        if (state == null)
        {
            Debug.Log("state가 null임");
            yield break;
        }

        Vector3 offset = isFacingRight ? new Vector3(0.5f, 0, 0) : new Vector3(-0.5f, 0, 0);
        Vector3 spawnPosition = shotPoint.position + offset;

        GameObject newBullet = Instantiate(bullet, shotPoint.position, Quaternion.identity);
        newBullet.transform.localScale = new Vector3(isFacingRight ? 1 : -1, 1, 1);

        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        Vector2 direction = isFacingRight ? Vector2.right : Vector2.left;
        rb.linearVelocity = direction * state.shootingSpeed;

        Bullet bulletScript = newBullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {

        }

        yield return new WaitForSeconds(state.shootingCooltime);
        allowShooting = true;
    }
}
