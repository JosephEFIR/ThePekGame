using Project.Scripts.Game.AI;
using Project.Scripts.Player;
using Zenject;

namespace Project.Scripts.Zenject
{
    public class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WaypointsContainer>().FromComponentsInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerController>().FromComponentsInHierarchy().AsSingle().NonLazy();
        }
    }
}