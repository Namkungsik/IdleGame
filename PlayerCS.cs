using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCS : MonoBehaviour
{
    public GameObject Monster; 

    public string PlayerName; // 플레이어 캐릭터 이름

    public int Current_HP; // 플레이어의 현재 체력
    public int HP; // 플레이어의 최대 체력

    public int Attack; // 플레이어의 공격력

    public Text _Name; // 화면 상에 나타나는 캐릭터 이름
    public Text _HP; // 화면 상에 나타나는 캐릭터의 체력

    public Animator Anim; // 플레이어 애니메이터

    public int Level; // 플레이어 레벨 수치
    public int Gold; // 플레이어 골드 수치
    public int Luck; // 플레이어 행운 수치

    public float Current_XP; // 플레이어 현재 경험치
    public float XP = 100; // 플레이어 최대 경험치

    public Image XP_Bar; // 플레이어 경험치 수치를 나타내는 이미지
    public Text Level_txt; // 화면상에 나타나는 현재 레벨
    public Text Attack_txt; // 화면상에 나타나는 현재 공격력
    public Text Gold_txt; // 화면상에 나타나는 현재 골드량

    public AudioSource Level_Sound; // 레벨업 사운드 오디오 소스

    private void Start()
    {
        Player_XP();
        _Name.text = PlayerName;
        Level = 1;
        Monster = GameObject.FindGameObjectWithTag("monster");
    }

    private void Update()
    {
        _HP.text = Current_HP + " / " + HP; // 체력수치 업데이트
        Level_txt.text = "LV " + Level; // 레벨 업데이트
        Attack_txt.text = "ATTACK : " + Attack;  // 공격력 업데이트
        Gold_txt.text = "GOLD : " + Gold + " G"; // 골드량 업데이트

        XP_Bar.fillAmount = Current_XP / XP; // 경험치량 업데이트

        if (Monster != null) // 몬스터 태그를 가진 오브젝트 존재 여부 파악
        {
            if (Monster.GetComponent<MonsterCS>().Current_HP > 0) // 몬스터가 죽지 않았을 때
            {
                Anim.SetInteger("AnimState", 1); // 공격 애니메이션 실행
            }
        }
        else if(Monster == null) // 죽었을 경우
        {
            Anim.SetInteger("AnimState", 2); // IDLE 애니메이션 실행
        }
    }

    public void AttackMonster() // 몬스터 공격 함수
    {
        Monster.GetComponent<MonsterCS>().Current_HP -= Attack;
    }

    public void Player_XP() // 플레이어 경험치 초기화
    {
        XP = Level * 100;
    }

    public void Level_UP() // 레벨업 함수
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
