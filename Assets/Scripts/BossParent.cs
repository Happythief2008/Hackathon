using UnityEngine;

public abstract class BossParent : MonoBehaviour
{
    [SerializeField]


    protected abstract void Attack();
    protected abstract void Move();

    // Update is called once per frame
    void Update()
    {
        
    }
}
