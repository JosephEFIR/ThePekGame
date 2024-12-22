using Project.Scripts.Player;
using UnityEngine;

namespace Project.Scripts.Combat
{
    public class PunchTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Rigidbody rb = other.GetComponentInParent<Rigidbody>();
            rb.AddForce(Vector3.back * 2000f, ForceMode.Impulse);
        }
    }
}