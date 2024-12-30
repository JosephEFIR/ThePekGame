using Project.Scripts.Animator;
using UnityEngine;

namespace Project.Scripts.Units
{
    public class TalkState : IState
    {
        private Unit _unit;
        
        public TalkState(Unit unit)
        {
            _unit = unit;
        }
        
        public void Enter()
        {
            _unit.Animator.SetTrigger(EAnimationType.Idle);
            _unit.Agent.SetDestination(_unit.transform.position);
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}