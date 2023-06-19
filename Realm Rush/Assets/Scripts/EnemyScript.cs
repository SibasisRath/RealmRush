using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenality = 25;
    BankScript bankScript;
    // Start is called before the first frame update
    void Start()
    {
        bankScript = FindObjectOfType<BankScript>();
    }

    public void RewardGold()
    {
        if (bankScript == null)
        {
            return;
        }
        else
        {
            bankScript.Deposit(goldReward);
        }
    }

    public void PenalityGold()
    {
        if (bankScript == null)
        {
            return;
        }
        else
        {
            bankScript.WithDwrawal(goldPenality);
        }
    }
}
