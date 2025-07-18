using UnityEngine;
using System.Collections;

public class player_move : MonoBehaviour
{
    Player_State state;
    bool canDash = true;
    bool isDashing = false;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        state = GetComponent<Player_State>();
    }

    void Update()
    {
        if (!isDashing)
        {
            PlayerMove();
            PlayerJump();
            PlayerDash();
        }
    }

    void PlayerMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 move = new Vector2(x, 0);
        transform.position += (Vector3)(move * state.PlayerMoveSpeed * Time.deltaTime);
    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && state.jumpCnt < 2)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // y속도만 초기화
            rb.AddForce(Vector2.up * state.jumpPower, ForceMode2D.Impulse);
            state.jumpCnt++;
        }
    }

    private void PlayerDash()
    {
        if (Input.GetKeyDown(KeyCode.L) && canDash)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            if (horizontal != 0)
            {
                StartCoroutine(DashCoroutine(horizontal));
            }
        }
    }

    private IEnumerator DashCoroutine(float direction)
    {
        canDash = false;
        isDashing = true;

        Vector2 originalVelocity = rb.linearVelocity;
        rb.linearVelocity = new Vector2(direction * state.dashspeed, 0); // 대시 y속도 제거

        yield return new WaitForSeconds(state.dashcoolTime);

        isDashing = false;
        rb.linearVelocity = originalVelocity;

        yield return new WaitForSeconds(state.dashcoolTime); // 쿨타임
        canDash = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            state.jumpCnt = 0;
        }
    }
}
