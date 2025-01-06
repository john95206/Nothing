using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using R3;
using UnityEngine;

namespace InputSystem
{
    public class UnityInputProvider : IInputProvider
    {
        private List<InputContent> _inputContentList = new List<InputContent>();
        public ReadOnlyCollection<InputContent> InputContentList => _inputContentList.AsReadOnly();
        public Observable<Unit> OnInputTypeDown(InputType inputType) => _inputContentList
            .FirstOrDefault(i => i.InputType == inputType)
            .OnButtonDown;
        public Observable<Unit> OnInputTypeUp(InputType inputType) => _inputContentList
            .FirstOrDefault (i => i.InputType == inputType)
            .OnButtonUp;
        public ReadOnlyReactiveProperty<bool> OnInputType(InputType inputType) => _inputContentList
            .FirstOrDefault(i => i.InputType == inputType)
            .OnButton;

        public UnityInputProvider()
        {
            CreateInputController();
            RegisterInputEvent();
        }

        private void CreateInputController()
        {
            var go = new GameObject();
            go.name = "InputController";
            var controller = go.AddComponent<InputController>();
            controller.Initialize(this);
        }

        private void RegisterInputEvent()
        {
            //_inputContentList.Add(new InputContent(KeyCode.A, KeyCode.LeftArrow, InputType.LEFT));
            //_inputContentList.Add(new InputContent(KeyCode.D, KeyCode.RightArrow, InputType.RIGHT));
            //_inputContentList.Add(new InputContent(KeyCode.W, KeyCode.UpArrow, InputType.TOP));
            //_inputContentList.Add(new InputContent(KeyCode.S, KeyCode.DownArrow, InputType.BOTTOM));
            _inputContentList.Add(new InputContent(KeyCode.Return, KeyCode.Return, InputType.SUBMIT));
            _inputContentList.Add(new InputContent(KeyCode.Escape, KeyCode.Q, InputType.CANCEL));
            //_inputContentList.Add(new InputContent(KeyCode.LeftShift, KeyCode.RightShift, InputType.SHIFT));
            _inputContentList.Add(new InputContent(KeyCode.Mouse0, KeyCode.Mouse0, InputType.MAINMOUSE));
            _inputContentList.Add(new InputContent(KeyCode.Mouse1, KeyCode.Mouse1, InputType.SUBMOUSE));
        }

        public void OnButtonDown(InputContent content)
        {
            if (Input.GetKeyDown(content.Main) || Input.GetKeyDown(content.Sub))
            {
                content.ButtonDown();
            }
        }

        public void OnButtonUp(InputContent content)
        {
            if (Input.GetKeyUp(content.Main) || Input.GetKeyUp(content.Sub))
            {
                content.ButtonUp();
            }
        }
    }
}
