using UniRx;

namespace Project.Scripts.Units
{
    public class TeacherUnit : Unit
    {
        protected override void Start()
        {
            base.Start();
            
            ChangeState(new FindWayState(this));
            _viewAngle.PlayerDetected.Subscribe(v =>
            {
                if (v)
                {
                    ChangeState(new TalkState(this));
                }
                else
                {
                    ChangeState(new FindWayState(this));
                }
            }).AddTo(_disposable);
        }
    }
}