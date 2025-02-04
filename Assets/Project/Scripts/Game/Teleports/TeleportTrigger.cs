using Project.Scripts.Player;
using UnityEngine;

namespace Project.Scripts.Game.Teleports
{
    public class TeleportTrigger : MonoBehaviour
    {
        [SerializeField] private Transform _teleportPos;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "PlayerCollider")
            {
                PlayerController player = other.gameObject.GetComponentInParent<PlayerController>();
                player.transform.position = _teleportPos.position;
                //FIX THIS BLYAT
            }
        }
    }
}