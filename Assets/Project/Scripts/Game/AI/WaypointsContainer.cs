using UnityEngine;

namespace Project.Scripts.Game.AI
{
    public class WaypointsContainer : MonoBehaviour
    {
        [SerializeField] private Transform[] waypoints;

        public Transform[] Waypoints => waypoints;
    }
}