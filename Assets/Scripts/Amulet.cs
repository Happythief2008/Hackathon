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
    // private string[] arrayClass = new string[8] { "���ݷ� ����", "���� �ӵ� ����", "���� ��Ÿ� ����", "�ҼӼ� �߰�", "ȭ�� ������ ����", "�˹� �Ÿ� ����", "ȸ���� ���� �ð� ����", "ȸ���� ��Ÿ�� �ð� ����" };
    private string[] arrayClass = new string[8] { "1", "2", "3", "4", "5", "6", "7", "8" };

    // �⺻�� ����� ������
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
            Debug.LogError("playerState�� null�Դϴ�. ���� Ȯ�� �ʿ�!");
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
            // Player_State �ڵ� ���� �õ�
            if (playerState == null)
            {
                playerState = FindObjectOfType<Player_State>();
                if (playerState == null)
                {
                    Debug.LogError("PlayerState�� ã�� �� �����ϴ�. Player_State ������Ʈ�� ���� ���� �����ϴ�.");
                    return;
                }
            }

            // Dropdown �ڵ� ���� �õ�
            if (dropdown == null)
            {
                dropdown = GetComponent<TMP_Dropdown>();
                if (dropdown == null)
                {
                    Debug.LogError("Dropdown�� �Ҵ���� �ʾҽ��ϴ�.");
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

            // ��Ӵٿ� �ɼ� �ʱ�ȭ
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
        LoadPlayerState(); // ���� ���� �ҷ�����
    }

    public void OnDropdownEvent(int index)
    {
        if (playerState == null)
            return;

        // ���� �� ���·� ����
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
