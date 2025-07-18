using UnityEngine;

public class long_distance_enemy : MonoBehaviour
{
    public Transform player;
    public float Speed=3f;
    [SerializeField] float recognize_distance ;
    [SerializeField] float CanAttack_distance;
    Vector3 direction;
    float distance;
    [SerializeField] GameObject bulletPrefab;
    public Transform firePoint;
    float shootdeleytime;
    [SerializeField]float maxshootdeleytime;
    public enum State{
        shoot,
        canrecongnize,
        norecongnize
    }
    private State _state=State.norecongnize;
    void Start()
    {
         player = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {   
        Vector3 dir = player.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        distance = Vector3.Distance(transform.position, player.position);
        if (CanAttack_distance <= distance&&distance<=recognize_distance)
        {
            _state=State.canrecongnize;
        }
        else if(CanAttack_distance>distance&&_state!=State.shoot)
        {
           _state=State.shoot;
        }
        
        switch(_state){
            case State.canrecongnize:
                shootdeleytime=0;
                direction = (player.position - transform.position).normalized;
                transform.position += new Vector3(direction.x * Speed * Time.deltaTime,0,0);
                break;
            case State.shoot:attack();break;
        }
    }
    public State state{
        get =>_state;
    }
    void attack(){
        if(shootdeleytime>=maxshootdeleytime){
            shootdeleytime=0;
            Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        }else{
            shootdeleytime+=Time.deltaTime;
        }
        
    }
}
