using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCS : MonoBehaviour
{
    public GameObject Player;

    public string [] MonsterName; // 몬스터의 이름
    public Sprite[] MonsterSprite; // 몬스터 스프라이트 배열

    public int Current_HP; // 몬스터의 현재 체력
    public int HP; // 몬스터의 최대 체력
    public int Attack; // 몬스터의 공격력
    public int XP; // 몬스터가 주는 경험치

    public Text _Name; // 화면 상에 나타나는 몬스터 이름
    public Text _HP; // 화면 상에 나타나는 몬스터의 체력
    public StageManager stage;

    public Animator Anim; // 몬스터 애니메이터
    public List<RuntimeAnimatorController> AnimList; // 특정 몬스터의 애니메이션 리스트
    public int currentDungeon = 0; // 현재 무슨 던전인지 결정하는 변수

    private void Start()
    {
        _Name.text = MonsterName[0];
        Anim.runtimeAnimatorController = AnimList[currentDungeon];
        Player = GameObject.FindGameObjectWithTag("player");
    }

    private void Update()
    {
        _HP.text = Current_HP + " / " + HP;
        if (Player != null) // 플레이어가 화면상에 존재할 때
        {
            if (Player.GetComponent<PlayerCS>().Current_HP > 0) // 몬스터가 죽지 않았을 때
            {
                Anim.SetInteger("AnimState", 1); // 공격 애니메이션 실행
            }
        }

        if (Current_HP <= 0) // 몬스터가 죽었을 때
        {
            Anim.SetInteger("AnimState", 2); // 사망 애니메이션 실행
            Player.GetComponent<PlayerCS>().Monster = null; // 사망 시 플레이어가 더 이상 몬스터가 없다는 정보를 전달
        }
    }

    public void AttackPlayer() // 플레이어 공격 함수
    {
        Player.GetComponent<PlayerCS>().Current_HP -= Attack;
    }

    public void Death() // 죽었을 때 호출하는 함수
    {
        var py = Player.GetComponent<PlayerCS>();
        int randomGold = Random.Range(1 + py.Luck, 11 + py.Luck); // 일정량의 골드 획득
        
        _Name.gameObject.SetActive(false);
        _HP.gameObject.SetActive(false);

        py.Current_XP += XP; // 특정 몬스터가 주는 경험치만큼 플레이어 현재 경험치로 전달
        py.Level_UP(); // 플레이어 레벨업 함수 호출
        py.Gold += randomGold; // 플레이어 현재 골드량에 몬스터 처치시 얻은 골드만큼 전달
        py.Current_HP += 5; // 몬스터 처치시 일정 체력 회복
        if(py.Current_HP >= py.HP) // 일정 체력 회복시 최대치를 넘지않도록 하는 조건
        {
            py.Current_HP = py.HP;
        }
    }
    
    public void OffObj()
    {
        this.gameObject.SetActive(false); // 해당 오브젝트 비활성화

        Invoke("Regen", 2); // 오브젝트 2초 후 부활
    }

    public void Regen() // 몬스터 부활 함수
    {
        CurrentMonster(); // 현재 몬스터 정보를 가져옴
        _Name.gameObject.SetActive(true);
        _HP.gameObject.SetActive(true);
        this.gameObject.SetActive(true);
        Player.GetComponent<PlayerCS>().Monster = this.gameObject;
    }

    private void CurrentMonster() // 현재 던전이 어디인지 파악하고 몬스터 정보 초기화
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
