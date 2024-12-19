using UnityEngine;

namespace Project.Scripts.Animator
{
    public enum EAnimationType
    {
        None,
        Idle,
        Walk,
        Run,
        Attack,
        AnimationID,
    }
    
    public class CustomAnimator : MonoBehaviour
    {
        private UnityEngine.Animator animator;
        
        private void Awake()
        {
            animator = GetComponent<UnityEngine.Animator>();
        }

        public void SetTrigger(EAnimationType animationType)
        {
            animator.SetTrigger(animationType.ToString());
        }

        public void SetBool(EAnimationType animationType, bool value)
        {
            animator.SetBool(animationType.ToString(), value);
        }

        public void SetMoveSpeed(float speed)
        {
            animator.SetFloat("Move", speed);
        }

        public void SetAnimID(int animID)
        {
            animator.SetInteger(EAnimationType.AnimationID.ToString(), animID);
        }
    }
}