using Services;
using UnityEngine.SceneManagement;
using Zenject;

namespace Installers
{
    public class BootstrapInstaller : MonoInstaller, IInitializable
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
            Container.BindInterfacesTo<InputService>().AsSingle();
        }

        public void Initialize()
        {
            SceneManager.LoadScene("Game");
        }
    }
}