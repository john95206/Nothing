using InputSystem;
using R3;
using UnityEngine;
using Zenject;

namespace Nothing
{
    public class PlayerController : MonoBehaviour
    {
        [Inject]
        private IInputProvider _inputProvider;

        [SerializeField]
        private TimelineController _timelineController;

        private ReactiveProperty<bool> _isPlaying = new();

        private CompositeDisposable _disposables = new();

        private void Start()
        {
            _inputProvider.OnInputTypeDown(InputType.MAINMOUSE)
            .Subscribe(_ =>
            {
                _isPlaying.Value = true;
            }).AddTo(_disposables);

            _inputProvider.OnInputTypeUp(InputType.MAINMOUSE)
            .Subscribe(_ =>
            {
                _isPlaying.Value = false;
            }).AddTo(_disposables);

            _isPlaying
            .Subscribe(isPlay =>
            {
                if (isPlay)
                {
                    _timelineController.Play();
                }
                else
                {
                    _timelineController.Resume();
                }
            }).AddTo(_disposables);
        }

        private void Update()
        {
            if (!_isPlaying.Value)
            {
                _timelineController.PlayBack();
            }
        }

        private void OnDestroy()
        {
            _disposables.Clear();
            _disposables.Dispose();
        }
    }
}
