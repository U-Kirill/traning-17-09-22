using Services;
using Services.Spell;
using Services.WorldRaycaster;
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
            Container.BindInterfacesTo<WorldRaycaster>().AsSingle();
            Container.BindInterfacesTo<GameFactory>().AsSingle();
            Container.BindInterfacesTo<SpellFactory>().AsSingle();
            Container.BindInterfacesTo<SpellService>().AsSingle();
        }

        public void Initialize()
        {
            SceneManager.LoadScene("Game");
        }
    }
}