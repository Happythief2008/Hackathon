using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class Amulet : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown dropdown;
    public Player_State playerState;
    public Store_Button Button;
    // private string[] arrayClass = new string[8] { "공격력 증가", "공격 속도 증가", "공격 사거리 증가", "불속성 추가", "화염 데미지 증가", "넉백 거리 증가", "회피의 무적 시간 증가", "회피의 쿨타임 시간 감소" };
    private string[] arrayClass = new string[8] { "1", "2", "3", "4", "5", "6", "7", "8" };

    // 기본값 복사용 변수들
    private int baseDamage;
    private float baseShootingCooltime;
    private float baseIntersection;
    private bool baseFire;
    private int baseFireDamage;
    private int baseKnockback;
    private float baseDashInvincibilityTime;
    private float baseDashCooltime;

    private string playerPrefsKey = "SavedPlayerState";

    public void SavePlayerState()
    {
        if (playerState == null)
        {
            Debug.LogError("playerState가 null입니다. 연결 확인 필요!");
            return;
        }

        PlayerPrefs.SetInt("Damage", playerState.Damage);
        PlayerPrefs.SetFloat("ShootingCooltime", playerState.shootingCooltime);
        PlayerPrefs.SetFloat("Intersection", playerState.intersection);
        PlayerPrefs.SetInt("Fire", playerState.fire ? 1 : 0);
        PlayerPrefs.SetInt("FireDamage", playerState.fireDamage);
        PlayerPrefs.SetInt("Knockback", playerState.Knockback);
        PlayerPrefs.SetFloat("DashInvincibilityTime", playerState.dashInvincibilityTime);
        PlayerPrefs.SetFloat("DashCooltime", playerState.dashcoolTime);

        PlayerPrefs.Save();
    }
    public void LoadPlayerState()
    {
        if (playerState == null)
            return;

        if (PlayerPrefs.HasKey("Damage"))
        {
            playerState.Damage = PlayerPrefs.GetInt("Damage");
            playerState.shootingCooltime = PlayerPrefs.GetFloat("ShootingCooltime");
            playerState.intersection = PlayerPrefs.GetFloat("Intersection");
            playerState.fire = PlayerPrefs.GetInt("Fire") == 1;
            playerState.fireDamage = PlayerPrefs.GetInt("FireDamage");
            playerState.Knockback = PlayerPrefs.GetInt("Knockback");
            playerState.dashInvincibilityTime = PlayerPrefs.GetFloat("DashInvincibilityTime");
            playerState.dashcoolTime = PlayerPrefs.GetFloat("DashCooltime");
        }
    }
    private void Awake()
    {
            // Player_State 자동 연결 시도
            if (playerState == null)
            {
                playerState = FindObjectOfType<Player_State>();
                if (playerState == null)
                {
                    Debug.LogError("PlayerState를 찾을 수 없습니다. Player_State 오브젝트가 현재 씬에 없습니다.");
                    return;
                }
            }

            // Dropdown 자동 연결 시도
            if (dropdown == null)
            {
                dropdown = GetComponent<TMP_Dropdown>();
                if (dropdown == null)
                {
                    Debug.LogError("Dropdown이 할당되지 않았습니다.");
                    return;
                }
            }

            baseDamage = playerState.Damage;
            baseShootingCooltime = playerState.shootingCooltime;
            baseIntersection = playerState.intersection;
            baseFire = playerState.fire;
            baseFireDamage = playerState.fireDamage;
            baseKnockback = playerState.Knockback;
            baseDashInvincibilityTime = playerState.dashInvincibilityTime;
            baseDashCooltime = playerState.dashcoolTime;

            // 드롭다운 옵션 초기화
            dropdown.ClearOptions();
            List<TMP_Dropdown.OptionData> optionList = new List<TMP_Dropdown.OptionData>();
            foreach (string str in arrayClass)
            {
                optionList.Add(new TMP_Dropdown.OptionData(str));
            }
            dropdown.AddOptions(optionList);

            dropdown.value = 0;
            dropdown.onValueChanged.AddListener(OnDropdownEvent);
    }

    void Start()
    {
        LoadPlayerState(); // 기존 상태 불러오기
    }

    public void OnDropdownEvent(int index)
    {
        if (playerState == null)
            return;

        // 선택 전 상태로 리셋
        playerState.Damage = baseDamage;
        playerState.shootingCooltime = baseShootingCooltime;
        playerState.intersection = baseIntersection;
        playerState.fire = baseFire;
        playerState.fireDamage = baseFireDamage;
        playerState.Knockback = baseKnockback;
        playerState.dashInvincibilityTime = baseDashInvincibilityTime;
        playerState.dashcoolTime = baseDashCooltime;

        if (Button.Check(index))
        {
            switch (index)
            {
                case 0: playerState.Damage += 5; break;
                case 1: playerState.shootingCooltime -= 5; break;
                case 2: playerState.intersection += 5; break;
                case 3: playerState.fire = true; break;
                case 4: playerState.fireDamage += 5; break;
                case 5: playerState.shootingCooltime -= 5; break;
                case 6: playerState.Knockback += 5; break;
                case 7: playerState.dashInvincibilityTime += 5; break;
                case 8: playerState.dashcoolTime -= 5; break;
                default: break;
            }
        }

        SavePlayerState();
    }
}
