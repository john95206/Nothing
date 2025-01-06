using InputSystem;
using UnityEngine;
using UnityEngine.Playables;
using Zenject;

namespace Nothing
{
    public class TimelineController : MonoBehaviour
    {
        [SerializeField]
        private PlayableDirector _timelinePlayable = default;

        public void Play()
        {
            if (_timelinePlayable.time > 0)
            {
                _timelinePlayable.Resume();
                return;
            }
            _timelinePlayable.Play();
        }

        public void Pause()
        {
            _timelinePlayable.Pause();
        }

        public void Resume()
        {
            if (_timelinePlayable.time <= 0)
            {
                _timelinePlayable.time = 0;
                return;
            }
            _timelinePlayable.Resume();
        }

        public void Test()
        {
        }

        public void PlayBack()
        {
            if (_timelinePlayable.time <= 0)
            {
                _timelinePlayable.time = 0;
                return;
            }
            _timelinePlayable.time -= Time.deltaTime;
        }
    }
}
