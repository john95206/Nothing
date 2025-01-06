using System;
using System.Collections.ObjectModel;
using R3;

namespace InputSystem
{
    public interface IInputProvider
    {
        ReadOnlyCollection<InputContent> InputContentList { get; }

        void OnButtonDown(InputContent inputContent);
        void OnButtonUp(InputContent inputContent);
        Observable<Unit> OnInputTypeDown(InputType inputType);
        Observable<Unit> OnInputTypeUp(InputType inputType);
        ReadOnlyReactiveProperty<bool> OnInputType(InputType inputType);
    }
}
