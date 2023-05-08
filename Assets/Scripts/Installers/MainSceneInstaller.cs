using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using ITB.Bullet;
using ITB.Common;
using ITB.Interfaces;
using ITB.Player;
using ITB.Player.Movement;
using UnityEngine;
using Zenject;

namespace ITB.Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private FastBullet fastBulletPrefab;
        [SerializeField] private SlowBullet slowBulletPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<CinemachineVirtualCamera>().FromComponentInHierarchy().AsSingle();
            
            Container.BindInterfacesAndSelfSingleNonLazy<GameInput>();
            Container.BindInterfacesAndSelfSingleNonLazy<CinemachineCameraController>();

            Container.Bind(typeof(Player.Player))
                .FromComponentInNewPrefab(playerPrefab)
                .AsSingle()
                .NonLazy();
            
            Container.BindInterfacesAndSelfSingleNonLazy<WalkingRunningMovement>();
            Container.Bind<Dictionary<MovementType, IMovementBehaviour>>().FromMethod(CreateMovementLookup).AsSingle();
            
            Container.BindMemoryPool<FastBullet, BulletPool<FastBullet>>()
                .WithInitialSize(5)
                .FromComponentInNewPrefab(fastBulletPrefab)
                .UnderTransformGroup("FastBulletPool");

            Container.BindMemoryPool<SlowBullet, BulletPool<SlowBullet>>()
                .WithInitialSize(3)
                .FromComponentInNewPrefab(slowBulletPrefab)
                .UnderTransformGroup("SlowBulletPool");
        }
        
        private Dictionary<MovementType, IMovementBehaviour> CreateMovementLookup(InjectContext context)
        {
            var movementBehaviours = context.Container.ResolveAll<IMovementBehaviour>();
            return movementBehaviours.ToDictionary(behaviour => behaviour.MovementType);
        }
    }
}