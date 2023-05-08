using Zenject;

namespace ITB.Common
{
    public static class Extentions
    {
        public static void BindInterfacesAndSelfSingleNonLazy<T>(this DiContainer container)
        {
            container.BindInterfacesAndSelfTo<T>().AsSingle().NonLazy();
        }
    }
}