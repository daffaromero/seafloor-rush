using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpManager : MonoBehaviour
{
    #region Singleton
    private static XpManager instance;
    public static XpManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("XpManager").AddComponent<XpManager>();
            }
            return instance;
        }
    }
    public delegate void XpChangeHandler(int amount);
    public event XpChangeHandler OnXpChange;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    #endregion

    public int TotalXp { get; private set; } = 0;

    public void AddXp(int amount)
    {
        TotalXp += amount;
        OnXpChange?.Invoke(amount);

        // Update PlayerPrefs
        PlayerPrefs.SetInt("totalXp", TotalXp);
    }

}
