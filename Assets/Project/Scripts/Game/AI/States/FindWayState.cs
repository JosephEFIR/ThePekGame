using UnityEngine;

namespace Project.Scripts.Units
{
    public class FindWayState : IState
    {
        private Unit _unit;
        
        public FindWayState(Unit unit)
        {
            _unit = unit;
        }
        
        public void Enter()
        {
            FindWay();
        }

        public void Update()
        {
            if (_unit.Distance.Value < 1)
            {
                int randomIndex = Random.Range(0, _unit.WaypointsContainer.Waypoints.Length);
                _unit.Target = _unit.WaypointsContainer.Waypoints[randomIndex];  
                _unit.Agent.SetDestination(_unit.Target.position); 
            }
        }

        private void FindWay()
        {
            int randomIndex = Random.Range(0, _unit.WaypointsContainer.Waypoints.Length);
            _unit.Target = _unit.WaypointsContainer.Waypoints[randomIndex];  
            _unit.Agent.SetDestination(_unit.Target.position); 
        }

        public void Exit()
        {
            
        }
    }
}