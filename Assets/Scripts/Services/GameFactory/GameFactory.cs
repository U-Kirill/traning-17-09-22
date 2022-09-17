using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Services.Spell
{
    public class GameFactory : MonoBehaviour, IGameFactory
    {
        [SerializeField] private GameObject _healingPedestal;
        
        private IInstantiator _instantiator;

        [Inject]
        public void Constructor(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }
           
        public GameObject CreateHealingPedestal(Vector3 position)
        {
            Debug.Log("Create");
            GameObject pedestal = _instantiator.InstantiatePrefab(_healingPedestal, position, Quaternion.identity, null);
            SceneManager.MoveGameObjectToScene(pedestal, SceneManager.GetActiveScene());
            return pedestal;
        }
    }
}