using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "UnitAudioConfig", menuName = "Configs/UnitAudioConfig")]
    public class UnitAudioConfig : ScriptableObject
    {
        [LabelText("Walk audio")]
        [SerializeField] private AudioClip walk;

        public AudioClip Walk => walk;
    }
}