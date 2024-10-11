using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCS : MonoBehaviour
{
    public GameObject Monster; 

    public string PlayerName; // �÷��̾� ĳ���� �̸�

    public int Current_HP; // �÷��̾��� ���� ü��
    public int HP; // �÷��̾��� �ִ� ü��

    public int Attack; // �÷��̾��� ���ݷ�

    public Text _Name; // ȭ�� �� ��Ÿ���� ĳ���� �̸�
    public Text _HP; // ȭ�� �� ��Ÿ���� ĳ������ ü��

    public Animator Anim; // �÷��̾� �ִϸ�����

    public int Level; // �÷��̾� ���� ��ġ
    public int Gold; // �÷��̾� ��� ��ġ
    public int Luck; // �÷��̾� ��� ��ġ

    public float Current_XP; // �÷��̾� ���� ����ġ
    public float XP = 100; // �÷��̾� �ִ� ����ġ

    public Image XP_Bar; // �÷��̾� ����ġ ��ġ�� ��Ÿ���� �̹���
    public Text Level_txt; // ȭ��� ��Ÿ���� ���� ����
    public Text Attack_txt; // ȭ��� ��Ÿ���� ���� ���ݷ�
    public Text Gold_txt; // ȭ��� ��Ÿ���� ���� ��差

    public AudioSource Level_Sound; // ������ ���� ����� �ҽ�

    private void Start()
    {
        Player_XP();
        _Name.text = PlayerName;
        Level = 1;
        Monster = GameObject.FindGameObjectWithTag("monster");
    }

    private void Update()
    {
        _HP.text = Current_HP + " / " + HP; // ü�¼�ġ ������Ʈ
        Level_txt.text = "LV " + Level; // ���� ������Ʈ
        Attack_txt.text = "ATTACK : " + Attack;  // ���ݷ� ������Ʈ
        Gold_txt.text = "GOLD : " + Gold + " G"; // ��差 ������Ʈ

        XP_Bar.fillAmount = Current_XP / XP; // ����ġ�� ������Ʈ

        if (Monster != null) // ���� �±׸� ���� ������Ʈ ���� ���� �ľ�
        {
            if (Monster.GetComponent<MonsterCS>().Current_HP > 0) // ���Ͱ� ���� �ʾ��� ��
            {
                Anim.SetInteger("AnimState", 1); // ���� �ִϸ��̼� ����
            }
        }
        else if(Monster == null) // �׾��� ���
        {
            Anim.SetInteger("AnimState", 2); // IDLE �ִϸ��̼� ����
        }
    }

    public void AttackMonster() // ���� ���� �Լ�
    {
        Monster.GetComponent<MonsterCS>().Current_HP -= Attack;
    }

    public void Player_XP() // �÷��̾� ����ġ �ʱ�ȭ
    {
        XP = Level * 100;
    }

    public void Level_UP() // ������ �Լ�
    {
        if(Current_XP >= XP)
        {
            Level_Sound.Play();
            Current_XP -= XP;
            Current_HP = HP;
            Level++;
            Player_XP();
        }
    }
}
