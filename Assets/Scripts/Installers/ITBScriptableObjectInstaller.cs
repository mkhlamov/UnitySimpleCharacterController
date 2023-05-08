using ITB.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace ITB.Installers
{
    [CreateAssetMenu(fileName = "ITBScriptableObjectInstaller", menuName = "ITB/Installers/ITBScriptableObjectInstaller")]
    public class ITBScriptableObjectInstaller : ScriptableObjectInstaller
    {
        public WalkingRunningMovementData WalkingRunningMovementData;

        public override void InstallBindings()
        {
            Container.BindInstance(WalkingRunningMovementData).AsSingle();
        }
    }
}