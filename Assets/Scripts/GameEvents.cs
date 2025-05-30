using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents
{
    public static GameEvents Instance;

    private void Awake()
    {
        Instance = this;
    }

    public event Action OnCoinCollected;

    public void CoinCollected()
    {
        if (OnCoinCollected != null) { OnCoinCollected.Invoke(); }      
    }
}
