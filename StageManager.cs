using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public Text stage;

    private void Start()
    {
        stage.text = "Stage 울창한 숲";
    }

    public void StageInfo(int DungeonStage)
    {
        if(DungeonStage == 0)
        {
            stage.text = "Stage 울창한 숲";
        }
        else if (DungeonStage == 1)
        {
            stage.text = "Stage 파괴된 유적";
        }
        else if (DungeonStage == 2)
        {
            stage.text = "Stage 불타는 던전";
        }
    }
}
