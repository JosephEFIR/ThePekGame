using System;
using Cysharp.Threading.Tasks;
using Project.Scripts.Game.Root;
using UniRx;
using Zenject;

namespace Project.Scripts.Game.Lesson
{
    public class LessonManager : IDisposable
    {
        [Inject] private GameManager _gameManager;
        
        public ReactiveProperty<float> CheelTimeSeconds = new();
        public ReactiveProperty<float> LessonTimeSeconds = new();
        
        private CompositeDisposable _disposable = new();

        [Inject]
        private void Init()
        {
            LessonTimeSeconds.Subscribe(v =>
            {
                if (v <= 0) _gameManager.PlayerSkipLesson.Value = true;
                else _gameManager.PlayerSkipLesson.Value = false;
            }).AddTo(_disposable);

            SetLesson(5 * 60);
        }
        
        public void SetCheelTime(int seconds)
        {
            CheelTimer(seconds).Forget();
        }
        
        public void SetLesson(int seconds)
        {
            LessonTimer(seconds).Forget();
        }
        
        // Асинхронный метод для запуска таймера
        private async UniTask CheelTimer(float duration)
        {
            while (duration > 0)
            {
                await UniTask.Delay(1000); // Задержка на 1 секунду
                duration -= 1f; // Уменьшаем оставшееся время на 1 секунду
                CheelTimeSeconds.Value = duration;
            }
        }

        private async UniTask LessonTimer(float duration)
        {
            while (duration > 0)
            {
                await UniTask.Delay(1000); // Задержка на 1 секунду
                duration -= 1f; // Уменьшаем оставшееся время на 1 секунду
                LessonTimeSeconds.Value = duration;
            }
        }

        public void Dispose()
        {
            _disposable?.Clear();
        }
    }
}