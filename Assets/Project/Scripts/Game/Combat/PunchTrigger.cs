using Project.Scripts.Configs;
using Project.Scripts.Player;
using Project.Scripts.Units;
using UnityEngine;

namespace Project.Scripts.Combat
{
    public class PunchTrigger : MonoBehaviour
    {
        [SerializeField] private TutorAudioConfig tutorAudioConfig;
        
        private TutorUnit _tutorUnit;
        private AudioSource _audioSource;
        
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _tutorUnit = GetComponentInParent<TutorUnit>();
        }

        private void Start()
        {
            _audioSource.clip = tutorAudioConfig.PunchAudioClip;
            _audioSource.volume = 0.3F;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(_tutorUnit.IsAttackMode is false) return;
            
            Rigidbody rb = other.GetComponentInParent<Rigidbody>(); //TODO FIX PLAYER CONTROLLER 
            rb.isKinematic = false;
            rb.AddForce(-transform.position * 200f, ForceMode.Impulse);
            
            _audioSource.Play();
        }
    }
}