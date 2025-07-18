using UnityEngine;

public class enemy_move : MonoBehaviour
{
    public Transform player;
    public float Speed=3f;
    [SerializeField] float CanAttack_distance;
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance >= CanAttack_distance)
        {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * Speed * Time.deltaTime;
        Vector3 dir = player.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
    }
}
