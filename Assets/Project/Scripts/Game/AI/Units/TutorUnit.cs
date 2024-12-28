using Project.Scripts.Game.Lesson;
using Project.Scripts.Game.Root;
using Project.Scripts.Player;
using UniRx;
using Zenject;

namespace Project.Scripts.Units
{
    public class TutorUnit : Unit
    {
        [Inject] private PlayerController _playerController;
        [Inject] private LessonManager _lessonManager;
        [Inject] private GameManager _gameManager;

        public bool IsAttackMode;
        
        protected override void Start()
        {
            base.Start();
            
            ChangeState(new FindWayState(this));
            
            _gameManager.PlayerSkipLesson.Subscribe(v =>
            {
                IsAttackMode = v;
                if(v) ChangeState(new AttackState(this, _playerController));
                else ChangeState(new FindWayState(this));
            }).AddTo(_disposable);
            
            _viewAngle.PlayerDetected.Subscribe(v =>
            {
                if (IsAttackMode is false)
                {
                    if (v)
                    {
                        ChangeState(new TalkState(this));
                    }
                    else
                    {
                        ChangeState(new FindWayState(this));
                    }
                }
            }).AddTo(_disposable);
        }
    }
}