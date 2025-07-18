using UnityEngine;

public class Store_Button : MonoBehaviour
{
    public int button = 0;
    public Player_State playerState;

    public bool Damage = false;
    public bool shootingCooltime = false;
    public bool intersection = false;
    public bool fire = false;
    public bool fireDamage = false;
    public bool Knockback = false;
    public bool dashInvincibilityTime = false;
    public bool dashcoolTime = false;

    private void Start()
    {
        playerState = FindObjectOfType<Player_State>();
    }

    // Update is called once per frame
    public void OnButtonClicked()
    {
        if (playerState.Wonhon >= 30)
            switch (button)
            {
                case 0: Damage = true; break;
                case 1: shootingCooltime = true; break;
                case 2: intersection = true; break;
                case 3: fire = true; break;
                case 4: fireDamage = true; break;
                case 5: Knockback = true; break;
                case 6: dashInvincibilityTime = true; break;
                case 7: dashcoolTime = true; break;
                default: break;
            }
    }

    public bool Check(int index)
    {
        switch (index)
        {
            case 0: return Damage;
            case 1: return shootingCooltime;
            case 2: return intersection;
            case 3: return fire;
            case 4: return fireDamage;
            case 5: return Knockback;
            case 6: return dashInvincibilityTime;
            case 7: return dashcoolTime;
            default: break;
        }
        return false;
    }
}
