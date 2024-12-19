using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Project.Scripts.Animator;
using UniRx;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Project.Scripts.Units
{
    public class TestUnit : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Transform[] waypoints;
        [SerializeField] private bool findWay;
        
        private CustomAnimator _animator;
        private NavMeshAgent _agent;
        
        private CancellationTokenSource _reloadToken;

        private ReactiveProperty<float> Distance = new();
        private CompositeDisposable _disposable = new();
        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<CustomAnimator>();
        }

        private void Start()
        {
            Distance.Subscribe(v =>
            {
                if (findWay)
                {
                    if (v < 1)
                    {
                        target = waypoints[Random.Range(0, waypoints.Length)].transform;
                    }
                }
            }).AddTo(_disposable);
        }

        private void Update()
        {
            Distance.Value = Vector3.Distance(target.position, transform.position);
                
            _animator.SetMoveSpeed(Mathf.Abs(_agent.velocity.magnitude));
            
            // if (distance > 20F)
            // {
            //     _agent.SetDestination(transform.position);
            //     _animator.SetTrigger(EAnimationType.Idle);
            // }
            //
            // if (distance < 20F & distance > 2)
            // {
            //     _agent.SetDestination(target.position);
            // }
            // if (distance <= 2)
            // {
            //     _agent.SetDestination(transform.position);
            //     Attack();
            //     SetCombo();
            //     
            // } 
        }

        private void Attack()
        {
            if (_reloadToken is null)
            {
                _animator.SetTrigger(EAnimationType.Attack);
                _agent.SetDestination(transform.position);
                SetCombo();
                Reload().Forget();
            }
        }

        private void SetCombo()
        {
            int comboID = Random.Range(0, 5);
            _animator.SetAnimID(comboID);
        }
        
        protected async UniTaskVoid Reload()
        {
            _reloadToken = new CancellationTokenSource();
            await UniTask.Delay(3, cancellationToken: _reloadToken.Token);
            StopTick();
        }

        protected void StopTick()
        {
            _reloadToken?.Cancel();
            _reloadToken?.Dispose();
            _reloadToken = null;
        }
    }
}