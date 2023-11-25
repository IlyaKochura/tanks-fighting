using Code.UI.Screens;
using Code.UI.Views;
using ScreenManager.Runtime.Contracts;
using UnityEngine;
using Zenject;

namespace Code.UI
{
    public class UiInstaller : MonoInstaller
    {
        [SerializeField] private DefeatView _defeatView;

        public override void InstallBindings()
        {
            Container.Bind<DefeatView>().FromInstance(_defeatView).AsSingle();

            Container.BindInterfacesAndSelfTo<DefeatScreen>().AsSingle();
        }

        public override void Start()
        {
            ResolveScreenManager();
        }

        private void ResolveScreenManager()
        {
            var screenManagers = Container.Resolve<IScreenManager>();
            
            screenManagers.Resolve(Container);
        }
    }
}