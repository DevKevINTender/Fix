using System.Collections.Generic;
using Data.Progress;
using Data.SaveLoad;
using UnityEngine;

namespace Data.SaveLoadPlayerProgress
{
    public class WeaponDataSerivce : IDataService
    {
        private readonly WeaponProgress _savedWeaponProgresses;

        private const string WeaponProgressKey = "WeaponProgress";
        
        public WeaponDataSerivce(WeaponProgress savedWeaponProgresses)
        {
            _savedWeaponProgresses = savedWeaponProgresses;
        }

        public void SaveWeaponProgress()
        {
     
        }
        
        public WeaponProgress LoadWeaponProgress() =>
            PlayerPrefs
                .GetString(WeaponProgressKey)
                .ToDeserialized<WeaponProgress>();
    }
}
