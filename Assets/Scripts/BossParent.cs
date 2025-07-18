using UnityEngine;

public abstract class BossParent : MonoBehaviour
{
    [SerializeField] float attackInterval;
    float attackTime;


    protected abstract void Attack();
    protected abstract void Move();

    // Update is called once per frame
    void Update()
    {
        attackTime += Time.deltaTime;
        if (attackTime >= attackInterval)
        {
            attackTime = 0;
            Attack();
        }
        Move();
    }
}
