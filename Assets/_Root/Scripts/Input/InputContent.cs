using System;
using R3;
using UnityEngine;

namespace InputSystem
{
    public class InputContent
    {
        public KeyCode Main;
        public KeyCode Sub;
        private InputType _inputType;
        public InputType InputType => _inputType;
        private Subject<Unit> _onButtonDown;
        public Observable<Unit> OnButtonDown => _onButtonDown;

        private Subject<Unit> _onButtonUp;
        public Observable<Unit> OnButtonUp => _onButtonUp;

        private readonly ReactiveProperty<bool> _onButton;
        public ReadOnlyReactiveProperty<bool> OnButton => _onButton;

        public InputContent(KeyCode main, KeyCode sub, InputType inputType)
        {
            Main = main;
            Sub = sub;
            _inputType = inputType;
            _onButtonDown = new Subject<Unit>();
            _onButtonUp = new Subject<Unit>();
            _onButton = new ();
        }

        public void ButtonDown()
        {
            _onButtonDown.OnNext(Unit.Default);
            _onButton.Value = true;
        }

        public void ButtonUp()
        {
            _onButtonUp.OnNext(Unit.Default);
            _onButton.Value = false;
        }
    }
}
