using System.Threading;
using Cysharp.Threading.Tasks;
using Project.Scripts.Animator;
using Project.Scripts.Player;
using UniRx;
using UnityEngine;

namespace Project.Scripts.Units
{
    public class AttackState : IState
    {
        private Unit _unit;
        private CancellationTokenSource _reloadToken;
        private PlayerController _player;

        private float _attackCooldown = 3f; // Пауза между атаками в секундах
        
        public AttackState(Unit unit, PlayerController player)
        {
            _unit = unit;
            _player = player;
        }
        
        public void Enter()
        {
            _unit.Agent.speed = 7;
            _unit.Target = _player.transform;
        }

        public void Update()
        {
            if (_unit.Distance.Value <= 2)
            {
                if (_reloadToken is null) // Проверяем, что нет активного ожидания
                { 
                    // Запускаем атаку и перезапускаем таймер
                    _unit.Animator.SetTrigger(EAnimationType.Attack);
                    _unit.Agent.SetDestination(_unit.transform.position);
                    SetCombo();
                    Reload().Forget();
                }
            }
            else
            {
                _unit.Agent.SetDestination(_player.transform.position);
                StopTick();
            }
        }

        public void Exit()
        {
            _unit.Agent.speed = 3;
        }
        
        private void SetCombo()
        {
            int comboID = Random.Range(0, 5);
            _unit.Animator.SetAnimID(comboID);
        }
        
        protected async UniTaskVoid Reload()
        {
            _reloadToken = new CancellationTokenSource();
            await UniTask.Delay((int)(_attackCooldown * 1000), cancellationToken: _reloadToken.Token); // Умножаем на 1000 для миллисекунд
            _reloadToken.Dispose(); // Освобождаем ресурсы после завершения
            _reloadToken = null; // Сбрасываем токен
        }
        
        protected void StopTick()
        {
            _reloadToken?.Cancel(); // Отменяем таймер, если он активен
            _reloadToken?.Dispose(); // Освобождаем ресурсы
            _reloadToken = null; // Сбрасываем токен
        }
    }
}