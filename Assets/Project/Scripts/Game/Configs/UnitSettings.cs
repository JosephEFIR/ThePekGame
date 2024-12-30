using System.Collections.Generic;
using Project.Scripts.Units;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "UnitSettings",  menuName = "Configs/UnitSettings")]
    public class UnitSettings : SerializedScriptableObject
    {
        [ListDrawerSettings(ShowFoldout = true, DraggableItems = false, HideRemoveButton = true)]
        
        [SerializeField]
        private Dictionary<EUnitStats, int> _unitStats = new()
        {
            {EUnitStats.Health, 100},
            {EUnitStats.Damage, 50},
            {EUnitStats.Speed, 7},
            {EUnitStats.PunchPower, 100},
        };

        public Dictionary<EUnitStats, int> UnitStats => _unitStats;
    }
}