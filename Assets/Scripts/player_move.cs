using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.U2D.IK;

public class player_move : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Rigidbody2D rb;
    [SerializeField] int maxjumpcount;
    [SerializeField] float jumppower;
    int jumpcount;
    void Start()
    {
        jumpcount=maxjumpcount;
        rb=GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        move();
        jump();
    }
    void move(){
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 move=new Vector2(x,0);
        transform.position+=(Vector3)(move*moveSpeed*Time.deltaTime);
    }
    void jump(){
        if(Input.GetKeyDown(KeyCode.W)&&jumpcount>0){
        jumpcount--;
        
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f);
        rb.linearVelocity=new Vector2(rb.linearVelocity.x,jumppower);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground")&&jumpcount!=maxjumpcount){
            jumpcount=maxjumpcount;
        }
    }
}
