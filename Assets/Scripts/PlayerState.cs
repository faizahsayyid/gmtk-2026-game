using UnityEngine;
using System;


[CreateAssetMenu(fileName = "PlayerState", menuName = "Scriptable Objects/PlayerState")]
public class PlayerState : ScriptableObject
{
    public Action OnShowBlackScreen;
    public int maxHealthPoints = 5;
    public int startingNumHalos = 10;
    public int maxLostSouls = 100;
    private int healthPoints;
    private int numHalos;
    private int lostSouls;


    public int GetHalos()
    {
        return numHalos;
    }

    public void ResetHalos()
    {
        numHalos = startingNumHalos;
    }

    public bool CanUseHalo()
    {
        return numHalos > 0;
    }

    public void UseHalo()
    {
        if (numHalos <= 0) return;
        numHalos -= 1;
    }

    public void CollectHalo(int n)
    {
        numHalos += n;
    }

    public void ResetHealth()
    {
        healthPoints = maxHealthPoints;
    }

    public void ResetLostSouls()
    {
        lostSouls = 0;
    }

    public int GetHealth()
    {
        return healthPoints;
    }

    public int GetLostSouls()
    {
        return lostSouls;
    }

    public void RegisterLostSoul()
    {
        lostSouls += 1;
        if (lostSouls >= maxLostSouls)
        {
            OnShowBlackScreen?.Invoke();
        }
    }

    public void TakeDamage(int damage)
    {
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            healthPoints = 0;
            OnShowBlackScreen?.Invoke();
        }
    }
}
