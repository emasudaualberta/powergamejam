using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class GameResource : MonoBehaviour
{
    public static GameResource Instance { get; private set; }

    public event Action OnManaChanged;
    public event Action OnPowerChanged;

    [SerializeField] private int manaAmount;
    [SerializeField] private int powerAmount;

    [SerializeField] private float recoveryInterval = 4.5f;
    [SerializeField] private int manaRecoveryAmount = 3;
    [SerializeField] private int powerRecoveryAmount = 1;

    public TMP_Text manaText;
    public TMP_Text powerText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        manaAmount = 10;
        powerAmount = 10;
        StartCoroutine(ManaRecovery());
        StartCoroutine(PowerRecovery());
        if (manaText != null)
            UpdateDisplayMana();
        if (powerText != null)
            UpdateDisplayPower();
        OnManaChanged += UpdateDisplayMana;
        OnPowerChanged += UpdateDisplayPower;
    }

    private IEnumerator ManaRecovery()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f); // mana every 2 seconds
            AddMana(manaRecoveryAmount);
        }
    }

    private IEnumerator PowerRecovery()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f); // power every 5 seconds
            AddPower(powerRecoveryAmount);
        }
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

    private void UpdateDisplayMana()
    {
        if (manaText != null)
            manaText.text = manaAmount.ToString();
    }

    private void UpdateDisplayPower()
    {
        if (powerText != null)
            powerText.text = powerAmount.ToString();
    }

    private void OnDestroy()
    {
        OnManaChanged -= UpdateDisplayMana;
        OnPowerChanged -= UpdateDisplayPower;
    }
}