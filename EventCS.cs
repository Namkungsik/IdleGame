using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EventCS : MonoBehaviour
{
    public GameObject Player;
    public GameObject Monster;

    // ���׷��̵� ���� �ؽ�Ʈ
    public Text AttackScript; 
    public Text HpScript;
    public Text LuckScript;

    // ���� ���� �ؽ�Ʈ
    public Text ForestScript; 
    public Text RuinScript; 
    public Text DungeonScript;

    // �ʱ� ���׷��̵� ����
    public int AttackLevel = 1;
    public int HpLevel = 1;
    public int LuckLevel = 1;

    // �ʱ� ���׷��̵� ���
    public int AtkCost = 10;
    public int HpCost = 10;
    public int LuckCost = 10;

    public Animator Anim; // ��ư Ŭ�� �ִϸ��̼�
    public int DragParam = 0; // �ִϸ��̼� �Ķ����

    // ����
    public AudioSource Upgrade_Sound;
    public AudioSource FailUpgrade_Sound;

    public void DragButton() // ��ư Ŭ�� �̺�Ʈ
    {
        if (DragParam == 0)
        {
            DragParam = 1;
            Anim.SetInteger("DragParam", DragParam);
        }
        else
        {
            DragParam = 2;
            Anim.SetInteger("DragParam", DragParam);
            DragParam = 0;
        }
    }

    // ���ݷ� ���׷��̵� ��ư ���� �Լ�
    public void OnAtkMouseEnter() // ���콺�� �÷����� �� ����
    {
        AttackScript.gameObject.SetActive(true);
        AttackScript.text = "LV : " + AttackLevel + "\n" + "Cost : " + AtkCost + "\n���ݷ� ����";
    }

    public void OnAtkMouseExit() // ���콺�� ����� �� 
    {
        AttackScript.gameObject.SetActive(false);
    }

    // ü�� ���׷��̵� ��ư ���� �Լ�
    public void OnHpMouseEnter()
    {
        HpScript.gameObject.SetActive(true);
        HpScript.text = "LV : " + HpLevel + "\n" + "Cost : " + HpCost + "\nü�� ����";
    }

    public void OnHpMouseExit()
    {
        HpScript.gameObject.SetActive(false);
    }

    // ��� ���׷��̵� ���� �Լ�
    public void OnLuckMouseEnter()
    {
        LuckScript.gameObject.SetActive(true);
        LuckScript.text = "LV : " + LuckLevel + "\n" + "Cost : " + LuckCost + "\n��� ����";
    }

    public void OnLuckMouseExit()
    {
        LuckScript.gameObject.SetActive(false);
    }

    // ���׷��̵� ��ư Ŭ�� �Լ�
    public void OnUpgradeButtonClick()
    {
        var py = Player.GetComponent<PlayerCS>();
        string ButtonName = EventSystem.current.currentSelectedGameObject.name;
        if (ButtonName == "UpgradeAtk")
        {
            if (AtkCost > py.Gold)
            {
                FailUpgrade_Sound.Play();
                Debug.Log("��ȭ ����");
            }
            else
            {
                AttackLevel++;
                py.Attack += 5;
                py.Gold -= AtkCost;
                AtkCost++;
                Upgrade_Sound.Play();
            }
        } // ���ݷ� ���׷��̵�
        else if (ButtonName == "UpgradeHp")
        {
            if (HpCost > py.Gold)
            {
                FailUpgrade_Sound.Play();
                Debug.Log("��ȭ ����");
            }
            else
            {
                HpLevel++;
                py.HP += 5;
                py.Gold -= HpCost;
                HpCost++;
                Upgrade_Sound.Play();
            }
        } // ü�� ���׷��̵�
        else if (ButtonName == "UpgradeLuck")
        {
            if (LuckCost > py.Gold)
            {
                FailUpgrade_Sound.Play();
                Debug.Log("��ȭ ����");
            }
            else
            {
                LuckLevel++;
                py.Luck += 1;
                py.Gold -= LuckCost;
                LuckCost++;
                Upgrade_Sound.Play();
            }
        } // ��� ���׷��̵�
    }

    // ���� ��ư ���� �Լ�
    public void OnForestMouseEnter()
    {
        ForestScript.gameObject.SetActive(true);
        ForestScript.text = "���� LV : 1 ~ 10" + "\n";
    }

    public void OnForestMouseExit()
    {
        ForestScript.gameObject.SetActive(false);
    }

    public void OnRuinMouseEnter()
    {
        RuinScript.gameObject.SetActive(true);
        RuinScript.text = "���� LV : 11 ~ 20" + "\n";
    }

    public void OnRuinMouseExit()
    {
        RuinScript.gameObject.SetActive(false);
    }

    public void OnDungeonMouseEnter()
    {
        DungeonScript.gameObject.SetActive(true);
        DungeonScript.text = "���� LV : 21 ~ 30" + "\n";
    }

    public void OnDungeonMouseExit()
    {
        DungeonScript.gameObject.SetActive(false);
    }

    public void OnDungeonButtonClick()
    {
        var my = Monster.GetComponent<MonsterCS>();
        string ButtonName = EventSystem.current.currentSelectedGameObject.name;
        if (ButtonName == "Forest")
        {
            my.currentDungeon = 0;
        }
        else if(ButtonName == "Ruin")
        {
            my.currentDungeon = 1;
        }
        else if (ButtonName == "Dungeon")
        {
            my.currentDungeon = 2;
        }
    }

}
