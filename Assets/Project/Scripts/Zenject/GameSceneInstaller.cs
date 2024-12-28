using Project.Scripts.Game.AI;
using Project.Scripts.Game.Lesson;
using Project.Scripts.Game.Root;
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
            
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LessonManager>().AsSingle().NonLazy();
        }
    }
}