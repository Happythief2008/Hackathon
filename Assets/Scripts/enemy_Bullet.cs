using UnityEngine;

public class enemy_Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float destoryTime=2f;
    void Start()
    {
        Destroy(gameObject,destoryTime);
    }
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
