using UnityEngine;
using Zenject;

namespace TankGameCore
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private CharacterStorage characterStorage;
        [SerializeField] private InputController inputControl;

        public override void InstallBindings()
        {
            Container.BindInstance(characterStorage).AsSingle();
            Container.BindInstance(inputControl).AsSingle();
        }
    }
}