using UnityEngine;
using Zenject;

namespace InputSystem
{
    public class InputController : MonoBehaviour
    {
        private IInputProvider _provider = default;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Initialize(IInputProvider inputProvider)
        {
            _provider = inputProvider;
        }

        private void Update()
        {
            if (_provider == null)
            {
                return;
            }

            foreach (var content in _provider.InputContentList)
            {
                _provider.OnButtonDown(content);
                _provider.OnButtonUp(content);
            }
        }
    }
}
