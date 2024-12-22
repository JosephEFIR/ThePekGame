using Project.Scripts.Animator;
using Project.Scripts.Configs;
using Project.Scripts.Game.AI;
using Project.Scripts.Game.AI.Test;
using UniRx;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Project.Scripts.Units
{
    public class Unit : MonoBehaviour
    {
        [Inject] public readonly WaypointsContainer WaypointsContainer;
        [SerializeField] private UnitAudioConfig audioConfig;
        
        [HideInInspector]
        public Transform Target ;

        private IState _currentState;
        
        public CustomAnimator Animator { get; private set; }
        public  NavMeshAgent Agent { get; private set; }
        private AudioSource _audioSource;

        [HideInInspector]
        public ReactiveProperty<float> Distance = new();
        
        private CompositeDisposable _disposable = new();
        
        private ViewAngle _viewAngle;
        
        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            _audioSource = GetComponent<AudioSource>();
            Animator = GetComponentInChildren<CustomAnimator>();
            _viewAngle = GetComponentInChildren<ViewAngle>();
        }

        private void Start()
        {
            _audioSource.clip = audioConfig.Walk; //TODO IS TEST
            ChangeState(new FindWayState(this));
            _viewAngle.PlayerDetected.Subscribe(v =>
            {
                if (v)
                {
                    ChangeState(new TalkState(this));
                }
                else
                {
                    ChangeState(new FindWayState(this));
                }
            }).AddTo(_disposable);
        }

        private void Update()
        {
            Distance.Value = Vector3.Distance(Target.position, transform.position);
            Animator.SetMoveSpeed(Mathf.Abs(Agent.velocity.magnitude));
            _currentState.Update();
            WalkSound();
        }

        private void WalkSound()
        {
            float distanceMoved = Agent.velocity.magnitude;
            float speed = distanceMoved / Time.deltaTime; // Скорость = расстояние / время
            
            _audioSource.pitch = Mathf.Lerp(0.8F, 1.2F, speed);
            
            if (speed > 1F && !_audioSource.isPlaying)
            {
                _audioSource.Play();
            }

            if (speed <= 0.1F && _audioSource.isPlaying)
            {
                _audioSource.Stop();
            }
        }

        public void ChangeState(IState state)
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState?.Enter();
        }
    }
}