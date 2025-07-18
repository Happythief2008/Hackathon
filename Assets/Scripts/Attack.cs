using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    [SerializeField] Player_State state;

    [Header("Prefabs & Points")]
    public GameObject bulletPrefab;
    public Transform shotPoint;

    [Header("Settings")]
    public float preShootDelay = 0.5f;
    bool allowShooting = true;

    bool isFacingRight = true;
    Animator animator;

    void Start()
    {
        state = FindObjectOfType<Player_State>();
        if (state == null)
            Debug.LogError("Player_State 컴포넌트를 찾을 수 없습니다!");

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput > 0) isFacingRight = true;
        else if (moveInput < 0) isFacingRight = false;

        if (Input.GetKeyDown(KeyCode.I) && allowShooting)
            StartCoroutine(ShootWithDelay(preShootDelay));
    }

    IEnumerator ShootWithDelay(float delay)
    {
        allowShooting = false;
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(delay);

        GameObject bulletGO = Instantiate(bulletPrefab, shotPoint.position, Quaternion.identity);

        // 방향에 따라 스케일 반전
        bulletGO.transform.localScale = new Vector3(isFacingRight ? 1 : -1, 1, 1);

        // Bullet 스크립트 설정
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.damage = state.Damage;
            bullet.speed = state.shootingSpeed;
            bullet.direction = isFacingRight ? Vector2.right : Vector2.left;
        }

        yield return new WaitForSeconds(state.shootingCooltime);
        allowShooting = true;
    }
}
