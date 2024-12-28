using UniRx;

namespace Project.Scripts.Game.Root
{
    public class GameManager
    {
        public ReactiveProperty<bool> PlayerSkipLesson = new();
    }
}