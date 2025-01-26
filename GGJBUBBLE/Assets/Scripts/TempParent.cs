using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TempParent : MonoBehaviour
{
    public static TempParent Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
