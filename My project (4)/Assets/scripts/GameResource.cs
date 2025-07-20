using System;
using System.Collections;
using UnityEngine;

public class GameResource : MonoBehaviour
{
    public static GameResource Instance { get; private set; }

    public event Action OnManaChanged;
    public event Action OnPowerChanged;

    [SerializeField] private int manaAmount;
    [SerializeField] private int powerAmount;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddMana(int amount)
    {
        manaAmount += amount;
        OnManaChanged?.Invoke();
    }

    public void AddPower(int amount)
    {
        powerAmount += amount;
        OnPowerChanged?.Invoke();
    }

    public bool SpendMana(int amount)
    {
        if (manaAmount >= amount)
        {
            manaAmount -= amount;
            OnManaChanged?.Invoke();
            return true;
        }
        return false;
    }

    public bool SpendPower(int amount)
    {
        if (powerAmount >= amount)
        {
            powerAmount -= amount;
            OnPowerChanged?.Invoke();
            return true;
        }
        return false;
    }

    public int GetMana() => manaAmount;
    public int GetPower() => powerAmount;

    public void KillReward(int mana, int power)
    {
        AddMana(mana);
        AddPower(power);
    }
}

public class NaturalResourceGeneration : MonoBehaviour
{
    [SerializeField] private float recoveryInterval = 2.5f;
    [SerializeField] private int manaRecoveryAmount = 1;
    [SerializeField] private int powerRecoveryAmount = 1;
    //[SerializeField] private Player player;
    //[SerializeField] private Generator generator;

    private void Start()
    {
        StartCoroutine(NaturalRecovery());
    }



    private IEnumerator NaturalRecovery()
    {
        while (true)
        {
            yield return new WaitForSeconds(recoveryInterval);
            int manaRecovery = manaRecoveryAmount; //make sure to multiply by player lvl later
            int powerRecovery = powerRecoveryAmount;
            if (GameResource.Instance != null)
            {
                GameResource.Instance.AddMana(manaRecoveryAmount);
                GameResource.Instance.AddPower(powerRecoveryAmount);
            }
        }
    }
}