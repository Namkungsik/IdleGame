using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public Text stage;

    private void Start()
    {
        stage.text = "Stage ��â�� ��";
    }

    public void StageInfo(int DungeonStage)
    {
        if(DungeonStage == 0)
        {
            stage.text = "Stage ��â�� ��";
        }
        else if (DungeonStage == 1)
        {
            stage.text = "Stage �ı��� ����";
        }
        else if (DungeonStage == 2)
        {
            stage.text = "Stage ��Ÿ�� ����";
        }
    }
}
