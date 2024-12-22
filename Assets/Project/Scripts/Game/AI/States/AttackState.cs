using System.Threading;
using Cysharp.Threading.Tasks;
using Project.Scripts.Animator;
using UnityEngine;

namespace Project.Scripts.Units
{
    public class AttackState : IState
    {
        private Unit _unit;
        private CancellationTokenSource _reloadToken;
        
        public AttackState(Unit unit)
        {
            _unit = unit;
        }
        
        public void Enter()
        {
            
        }

        public void Update()
        {
            Attack();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
        
        private void Attack()
        {
            if (_reloadToken is null)
            { 
                _unit.Animator.SetTrigger(EAnimationType.Attack);
                _unit.Agent.SetDestination(_unit.transform.position);
                SetCombo();
                Reload().Forget();
            }
        }
        
        private void SetCombo()
        {
            int comboID = Random.Range(0, 5);
            _unit.Animator.SetAnimID(comboID);
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