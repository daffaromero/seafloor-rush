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
                instance = FindObjectOfType<XpManager>();

                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(XpManager).Name;
                    instance = obj.AddComponent<XpManager>();
                }
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
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    public void AddXp(int amount)
    {
        OnXpChange?.Invoke(amount);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
