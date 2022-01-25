using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerRanking : Singleton<PlayerRanking>
{
    [SerializeField] private List<Transform> ListAI;
    [SerializeField] private Transform Player;
    public Text rank;

    private void Update()
    {
        rank.text = Sorter().ToString();        
    }
    private int Sorter()
    {
        int count = 1;
        for (int i = 0; i < ListAI.Count-1; i++)
        {
            if (Player.transform.position.z < ListAI[i].transform.position.z)
            {
                count++;
            }
        }
        return count;
    }
}
