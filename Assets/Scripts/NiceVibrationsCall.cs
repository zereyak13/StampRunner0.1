using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;
public class NiceVibrationsCall : MonoBehaviour
{
    public static NiceVibrationsCall Instance;

    private void Awake()
    {
        Instance = this;
    }


    public void SuccesVibration()
    {
        MMVibrationManager.Haptic(HapticTypes.Success, false, true, this);
    }
}
