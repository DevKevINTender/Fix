using System.Collections.Generic;
using Data.Progress;
using Data.SaveLoad;
using UnityEngine;

namespace Data.SaveLoadPlayerProgress
{
    public class SaveLoad : ISaveLoad
    {
        private readonly ISavedProgressData _progress;
        private readonly List<ISaveLoadProgress<PlayerProgress>> _savedPlayerProgresses;
        private readonly List<ISaveLoadProgress<WeaponProgress>> _savedWeaponProgresses;

        private const string PlayerProgressKey = "PlayerProgress";
        private const string WeaponProgressKey = "WeaponProgress";
        
        public SaveLoad(ISavedProgressData progress, List<ISaveLoadProgress<PlayerProgress>> savedPlayerPlayerProgresses, List<ISaveLoadProgress<WeaponProgress>> savedWeaponProgresses)
        {
            _progress = progress;
            _savedPlayerProgresses = savedPlayerPlayerProgresses;
            _savedWeaponProgresses = savedWeaponProgresses;
        }

        public void SaveProgress()
        {
            if (_savedPlayerProgresses != null)
            {
                for (int i = 0; i < _savedPlayerProgresses.Count; i++)
                {
                    _savedPlayerProgresses[i].UpdateProgress(_progress.PlayerProgress);
                }
            }
            
            if (_savedWeaponProgresses != null)
            {
                for (int i = 0; i < _savedWeaponProgresses.Count; i++)
                {
                    _savedWeaponProgresses[i].UpdateProgress(_progress.WeaponProgress);
                }
            }

            PlayerPrefs.SetString(PlayerProgressKey, _progress.PlayerProgress.ToJson());
            PlayerPrefs.SetString(WeaponProgressKey, _progress.WeaponProgress.ToJson());
        }

        public PlayerProgress LoadPlayerProgress() =>
            PlayerPrefs
                .GetString(PlayerProgressKey)
                .ToDeserialized<PlayerProgress>();

        public WeaponProgress LoadWeaponProgress() =>
            PlayerPrefs
                .GetString(WeaponProgressKey)
                .ToDeserialized<WeaponProgress>();
    }
}
