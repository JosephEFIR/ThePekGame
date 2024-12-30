using System;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Game.Lesson
{
    public class BreakTimeUI : MonoBehaviour
    {
        [Inject] private LessonManager _lessonManager;
        private TextMeshProUGUI _textMeshPro;

        private CompositeDisposable _disposable = new();

        private void Awake()
        {
            _textMeshPro = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            _lessonManager.LessonTimeSeconds.Subscribe(v =>
            {
                if (v > 0)
                {
                    _textMeshPro.text = v.ToString();
                    _textMeshPro.color = Color.green;
                }
                else
                {
                    _textMeshPro.text = String.Empty;
                }
            }).AddTo(_disposable);
        }

        private void OnDestroy()
        {
            _disposable.Clear();
        }
    }
}