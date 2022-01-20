
    using UnityEngine;
    using Zenject;

    public class Installer : MonoInstaller
    {
        [SerializeField] private LinkLevelDataProvider _linkLevelDataProvider;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DesktopInput>().AsSingle();
            Container.Bind<Camera>().FromInstance(Camera.main).AsSingle();
            Container.BindInterfacesAndSelfTo<ILevelDataProvider>().FromInstance(_linkLevelDataProvider).AsSingle();
        }
    }
