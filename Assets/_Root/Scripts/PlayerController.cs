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

        private void Start()
        {
            _inputProvider.OnInputTypeDown(InputType.MAINMOUSE)
            .Subscribe(_ =>
            {
                _isPlaying.Value = true;
            }).AddTo(this);

            _inputProvider.OnInputTypeUp(InputType.MAINMOUSE)
            .Subscribe(_ =>
            {
                _isPlaying.Value = false;
            }).AddTo(this);

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
            }).AddTo(this);
        }

        private void Update()
        {
            if (!_isPlaying.Value)
            {
                _timelineController.PlayBack();
            }
        }
    }
}
