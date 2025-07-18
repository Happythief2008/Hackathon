using UnityEditor.Experimental.GraphView;
using UnityEngine;
using System.Collections;
public class vicinity_enemy_move : MonoBehaviour
{
    public Transform player;
    public float Speed = 3f;
    [SerializeField] float recognize_distance ;
    [SerializeField] float CanAttack_distance;
    Vector3 direction;
    float distance;
    [SerializeField] float DashSpeed;
    [SerializeField]bool movestop=false;

    public Player_State playerState;

    public enum State{
        rush,
        canrecongnize,
        norecongnize
    }
    private State _state=State.norecongnize;
    void Start()
    {
        playerState = FindObjectOfType<Player_State>();
        player = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {   
        
        if(!movestop){
        distance = Vector3.Distance(transform.position, player.position);
        if (CanAttack_distance <= distance&&distance<=recognize_distance)
        {
            if(_state==State.rush)
            StartCoroutine(Stoptime());
            else if(state!=State.rush){
                _state=State.canrecongnize;
            }
        }
        else if(CanAttack_distance>distance&&_state!=State.rush)
        {
           _state=State.rush;
        }
        switch(_state){
            case State.canrecongnize:
                direction = (player.position - transform.position).normalized;
                transform.position += new Vector3(direction.x * Speed * Time.deltaTime,0,0);
                break;
            case State.rush:StartCoroutine(Rush());break;
        }
    }
    else if(movestop){

    }
    }
    public State state{
        get =>_state;
    }
    IEnumerator Rush(){
        yield return new WaitForSeconds(0.3f);
        if(!movestop)
        transform.position += new Vector3(DashSpeed*direction.x* Speed * Time.deltaTime,0,0);
    }
    IEnumerator Stoptime(){
        movestop=true;
        yield return new WaitForSeconds(1f);
        _state=State.canrecongnize;
        movestop=false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            movestop=true;

            //player.GetComponent<player_move>()?.TakeDamage(Damage);
        }
    }
     private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            movestop=false;
        }
     }
}
