using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCS : MonoBehaviour
{
    public GameObject Player;

    public string [] MonsterName; // ������ �̸�
    public Sprite[] MonsterSprite; // ���� ��������Ʈ �迭

    public int Current_HP; // ������ ���� ü��
    public int HP; // ������ �ִ� ü��
    public int Attack; // ������ ���ݷ�
    public int XP; // ���Ͱ� �ִ� ����ġ

    public Text _Name; // ȭ�� �� ��Ÿ���� ���� �̸�
    public Text _HP; // ȭ�� �� ��Ÿ���� ������ ü��
    public StageManager stage;

    public Animator Anim; // ���� �ִϸ�����
    public List<RuntimeAnimatorController> AnimList; // Ư�� ������ �ִϸ��̼� ����Ʈ
    public int currentDungeon = 0; // ���� ���� �������� �����ϴ� ����

    private void Start()
    {
        _Name.text = MonsterName[0];
        Anim.runtimeAnimatorController = AnimList[currentDungeon];
        Player = GameObject.FindGameObjectWithTag("player");
    }

    private void Update()
    {
        _HP.text = Current_HP + " / " + HP;
        if (Player != null) // �÷��̾ ȭ��� ������ ��
        {
            if (Player.GetComponent<PlayerCS>().Current_HP > 0) // ���Ͱ� ���� �ʾ��� ��
            {
                Anim.SetInteger("AnimState", 1); // ���� �ִϸ��̼� ����
            }
        }

        if (Current_HP <= 0) // ���Ͱ� �׾��� ��
        {
            Anim.SetInteger("AnimState", 2); // ��� �ִϸ��̼� ����
            Player.GetComponent<PlayerCS>().Monster = null; // ��� �� �÷��̾ �� �̻� ���Ͱ� ���ٴ� ������ ����
        }
    }

    public void AttackPlayer() // �÷��̾� ���� �Լ�
    {
        Player.GetComponent<PlayerCS>().Current_HP -= Attack;
    }

    public void Death() // �׾��� �� ȣ���ϴ� �Լ�
    {
        var py = Player.GetComponent<PlayerCS>();
        int randomGold = Random.Range(1 + py.Luck, 11 + py.Luck); // �������� ��� ȹ��
        
        _Name.gameObject.SetActive(false);
        _HP.gameObject.SetActive(false);

        py.Current_XP += XP; // Ư�� ���Ͱ� �ִ� ����ġ��ŭ �÷��̾� ���� ����ġ�� ����
        py.Level_UP(); // �÷��̾� ������ �Լ� ȣ��
        py.Gold += randomGold; // �÷��̾� ���� ��差�� ���� óġ�� ���� ��常ŭ ����
        py.Current_HP += 5; // ���� óġ�� ���� ü�� ȸ��
        if(py.Current_HP >= py.HP) // ���� ü�� ȸ���� �ִ�ġ�� �����ʵ��� �ϴ� ����
        {
            py.Current_HP = py.HP;
        }
    }
    
    public void OffObj()
    {
        this.gameObject.SetActive(false); // �ش� ������Ʈ ��Ȱ��ȭ

        Invoke("Regen", 2); // ������Ʈ 2�� �� ��Ȱ
    }

    public void Regen() // ���� ��Ȱ �Լ�
    {
        CurrentMonster(); // ���� ���� ������ ������
        _Name.gameObject.SetActive(true);
        _HP.gameObject.SetActive(true);
        this.gameObject.SetActive(true);
        Player.GetComponent<PlayerCS>().Monster = this.gameObject;
    }

    private void CurrentMonster() // ���� ������ ������� �ľ��ϰ� ���� ���� �ʱ�ȭ
    {
        switch (currentDungeon)
        {
            case 0:
                HP = 30;
                Current_HP = 30;
                Attack = 5;
                XP = 10;
                _Name.text = MonsterName[currentDungeon];
                Anim.runtimeAnimatorController = AnimList[currentDungeon];
                stage.StageInfo(currentDungeon);
                break;
            case 1:
                HP = 70;
                Current_HP = 70;
                Attack = 10;
                XP = 20;
                _Name.text = MonsterName[currentDungeon];
                Anim.runtimeAnimatorController = AnimList[currentDungeon];
                stage.StageInfo(currentDungeon);
                break;
            case 2:
                HP = 100;
                Current_HP = 100;
                Attack = 15;
                XP = 30;
                _Name.text = MonsterName[currentDungeon];
                Anim.runtimeAnimatorController = AnimList[currentDungeon];
                stage.StageInfo(currentDungeon);
                break;
        }
    }
}
