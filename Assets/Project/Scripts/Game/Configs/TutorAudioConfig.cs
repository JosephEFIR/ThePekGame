using UnityEngine;

namespace Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "TutorAudioConfig", menuName = "Configs/TutorAudioConfig")]
    public class TutorAudioConfig : UnitAudioConfig
    {
        [SerializeField] private AudioClip _swingAudioClip;
        [SerializeField] private AudioClip _punchAudioClip;

        public AudioClip SwingAudioClip => _swingAudioClip;
        public AudioClip PunchAudioClip => _punchAudioClip;
    }
}