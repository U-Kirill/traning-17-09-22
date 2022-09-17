using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class BootstrapInstaller : MonoInstaller, IInitializable
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
    }

    public void Initialize()
    {
        SceneManager.LoadScene("Game");
    }
}