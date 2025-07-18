using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.U2D.IK;

public class player_move : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        PlayeMove();
    }

    void PlayeMove(){
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 move=new Vector2(x,0);
        transform.position+=(Vector3)(move*moveSpeed*Time.deltaTime);
    }

    void PlayerDash()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            // rb.AddForce(Vector2.right*)
        }
    }
}
