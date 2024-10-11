using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EventCS : MonoBehaviour
{
    public GameObject Player;
    public GameObject Monster;

    // 업그레이드 설명 텍스트
    public Text AttackScript; 
    public Text HpScript;
    public Text LuckScript;

    // 던전 설명 텍스트
    public Text ForestScript; 
    public Text RuinScript; 
    public Text DungeonScript;

    // 초기 업그레이드 레벨
    public int AttackLevel = 1;
    public int HpLevel = 1;
    public int LuckLevel = 1;

    // 초기 업그레이드 비용
    public int AtkCost = 10;
    public int HpCost = 10;
    public int LuckCost = 10;

    public Animator Anim; // 버튼 클릭 애니메이션
    public int DragParam = 0; // 애니메이션 파라미터

    // 사운드
    public AudioSource Upgrade_Sound;
    public AudioSource FailUpgrade_Sound;

    public void DragButton() // 버튼 클릭 이벤트
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

    // 공격력 업그레이드 버튼 관련 함수
    public void OnAtkMouseEnter() // 마우스에 올려졌을 때 설명
    {
        AttackScript.gameObject.SetActive(true);
        AttackScript.text = "LV : " + AttackLevel + "\n" + "Cost : " + AtkCost + "\n공격력 증가";
    }

    public void OnAtkMouseExit() // 마우스가 벗어났을 때 
    {
        AttackScript.gameObject.SetActive(false);
    }

    // 체력 업그레이드 버튼 관련 함수
    public void OnHpMouseEnter()
    {
        HpScript.gameObject.SetActive(true);
        HpScript.text = "LV : " + HpLevel + "\n" + "Cost : " + HpCost + "\n체력 증가";
    }

    public void OnHpMouseExit()
    {
        HpScript.gameObject.SetActive(false);
    }

    // 행운 업그레이드 관련 함수
    public void OnLuckMouseEnter()
    {
        LuckScript.gameObject.SetActive(true);
        LuckScript.text = "LV : " + LuckLevel + "\n" + "Cost : " + LuckCost + "\n행운 증가";
    }

    public void OnLuckMouseExit()
    {
        LuckScript.gameObject.SetActive(false);
    }

    // 업그레이드 버튼 클릭 함수
    public void OnUpgradeButtonClick()
    {
        var py = Player.GetComponent<PlayerCS>();
        string ButtonName = EventSystem.current.currentSelectedGameObject.name;
        if (ButtonName == "UpgradeAtk")
        {
            if (AtkCost > py.Gold)
            {
                FailUpgrade_Sound.Play();
                Debug.Log("강화 실패");
            }
            else
            {
                AttackLevel++;
                py.Attack += 5;
                py.Gold -= AtkCost;
                AtkCost++;
                Upgrade_Sound.Play();
            }
        } // 공격력 업그레이드
        else if (ButtonName == "UpgradeHp")
        {
            if (HpCost > py.Gold)
            {
                FailUpgrade_Sound.Play();
                Debug.Log("강화 실패");
            }
            else
            {
                HpLevel++;
                py.HP += 5;
                py.Gold -= HpCost;
                HpCost++;
                Upgrade_Sound.Play();
            }
        } // 체력 업그레이드
        else if (ButtonName == "UpgradeLuck")
        {
            if (LuckCost > py.Gold)
            {
                FailUpgrade_Sound.Play();
                Debug.Log("강화 실패");
            }
            else
            {
                LuckLevel++;
                py.Luck += 1;
                py.Gold -= LuckCost;
                LuckCost++;
                Upgrade_Sound.Play();
            }
        } // 행운 업그레이드
    }

    // 던전 버튼 관련 함수
    public void OnForestMouseEnter()
    {
        ForestScript.gameObject.SetActive(true);
        ForestScript.text = "적정 LV : 1 ~ 10" + "\n";
    }

    public void OnForestMouseExit()
    {
        ForestScript.gameObject.SetActive(false);
    }

    public void OnRuinMouseEnter()
    {
        RuinScript.gameObject.SetActive(true);
        RuinScript.text = "적정 LV : 11 ~ 20" + "\n";
    }

    public void OnRuinMouseExit()
    {
        RuinScript.gameObject.SetActive(false);
    }

    public void OnDungeonMouseEnter()
    {
        DungeonScript.gameObject.SetActive(true);
        DungeonScript.text = "적정 LV : 21 ~ 30" + "\n";
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
