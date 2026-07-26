using UnityEngine;
using System;


[CreateAssetMenu(fileName = "PlayerState", menuName = "Scriptable Objects/PlayerState")]
public class PlayerState : ScriptableObject
{
    public Action OnShowBlackScreen;
    public int maxHealthPoints = 5;
    public int startingNumHalos = 10;
    private int healthPoints;
    private int numHalos;


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

    public int GetHealth()
    {
        return healthPoints;
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
