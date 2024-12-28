using System;
using UnityEngine;

namespace Project.Scripts.Player
{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbody;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Ground")
            {
                Debug.Log("ground");
                rigidbody.isKinematic = true;
            }
        }
    }
}