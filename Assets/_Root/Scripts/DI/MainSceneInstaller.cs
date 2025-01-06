using InputSystem;
using UnityEngine;
using Zenject;

public class MainSceneInstaller : MonoInstaller<MainSceneInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<UnityInputProvider>().FromNew().AsCached();
    }
}