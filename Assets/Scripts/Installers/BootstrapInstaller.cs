using Services;
using Services.Spell;
using Services.WorldRaycaster;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Installers
{
    public class BootstrapInstaller : MonoInstaller, IInitializable
    {
        [SerializeField] private GameFactory _gameFactory;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
            
            Container.Bind<IGameFactory>().FromMethod(() => Container.InstantiatePrefabForComponent<IGameFactory>(_gameFactory)).AsSingle();
            
            Container.BindInterfacesTo<InputService>().AsSingle();
            Container.BindInterfacesTo<WorldRaycaster>().AsSingle();
            Container.BindInterfacesTo<SpellFactory>().AsSingle();
            Container.BindInterfacesTo<SpellService>().AsSingle();
            Container.Bind<PlayerHolder>().AsSingle();
        }

        public void Initialize()
        {
            SceneManager.LoadScene("Game");
        }
    }
}