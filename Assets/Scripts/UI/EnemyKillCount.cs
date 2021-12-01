using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyKillCount : MonoBehaviour
{
    static TextMeshProUGUI killEnemyCount1;
    public static int killEnemyCount;

    public void Start()
    {
        killEnemyCount1 = GetComponent<TextMeshProUGUI>();
    }
    public static void SetKillCount()
    {
        int count = int.Parse(killEnemyCount1.text);
        killEnemyCount1.text = (count + 1).ToString();

        //killEnemyCount1.text = killEnemyCount.ToString();
    }
}
