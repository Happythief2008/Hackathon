using UnityEngine;
using System.Collections;

public class player_move : MonoBehaviour
{
    Player_State state;
    bool canDash = true;
    bool isDashing = false;
    bool isJumping = false; // 추가
    Animator animator;

    Rigidbody2D rb;
    SpriteRenderer playerSpriteRenderer;

    Coroutine stopRunningCoroutine;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        state = GetComponent<Player_State>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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

        if (x != 0)
        {
            if (stopRunningCoroutine != null)
            {
                StopCoroutine(stopRunningCoroutine);
                stopRunningCoroutine = null;
            }

            playerSpriteRenderer.flipX = x < 0;
            animator.SetBool("Isrunning", true);
        }
        else
        {
            if (stopRunningCoroutine == null)
            {
                stopRunningCoroutine = StartCoroutine(StopRunningDelayed());
            }
        }
    }

    IEnumerator StopRunningDelayed()
    {
        yield return new WaitForSeconds(0.045f);
        animator.SetBool("Isrunning", false);
        stopRunningCoroutine = null;
    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && state.jumpCnt < 2)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            rb.AddForce(Vector2.up * state.jumpPower, ForceMode2D.Impulse);
            state.jumpCnt++;
            isJumping = true;
            animator.SetBool("Isjumping", true);
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
        rb.linearVelocity = new Vector2(direction * state.dashspeed, 0);

        yield return new WaitForSeconds(state.dashcoolTime);

        isDashing = false;
        rb.linearVelocity = originalVelocity;

        yield return new WaitForSeconds(state.dashcoolTime);
        canDash = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            state.jumpCnt = 0;
            isJumping = false;
            animator.SetBool("Isjumping", false);
        }
    }

    public void TakeDamage(int Damage)
    {
        state.Hp -= Damage;
        Debug.Log($"{gameObject.name}이(가) {Damage}의 데미지를 받았습니다. 현재 체력: {state.Hp}");

        if (state.Hp <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log($"{gameObject.name}이(가) 사망했습니다.");

        Destroy(gameObject);
    }
}
