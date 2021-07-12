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
    public void HeavyVibration()
    {
        MMVibrationManager.Haptic(HapticTypes.HeavyImpact, false, true, this);
    }
    public void MediumVibration()
    {
        MMVibrationManager.Haptic(HapticTypes.MediumImpact, false, true, this);
    }
    public void LightVibration()
    {
        MMVibrationManager.Haptic(HapticTypes.LightImpact, false, true, this);
    }
}
