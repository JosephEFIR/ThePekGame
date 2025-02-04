using Project.Scripts.Player;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Game.Root
{
    public class DeathZone : MonoBehaviour
    {
        [Inject] private PlayerController _playerController;
        [SerializeField] private Transform _teleportPosition;
        

        private void FixedUpdate()
        {
            if (_playerController.transform.position.y < -60)
            {
                _playerController.transform.position = _teleportPosition.position;
            }
        }
    }
}