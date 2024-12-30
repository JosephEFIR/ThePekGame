using Project.Scripts.Player;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Game.AI
{
    public class CharacterName : MonoBehaviour
    {
        [Inject] private PlayerController _playerController;

        private void FixedUpdate()
        {
            Vector3 direction = _playerController.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
        
            // Поворачиваем текст, добавляя 180 градусов по оси Y
            transform.rotation = Quaternion.Euler(0, rotation.eulerAngles.y + 180, 0);
            
        }
    }
}