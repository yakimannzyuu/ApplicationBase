using Manager.VContainer;
using VContainer;
using VContainer.Unity;

namespace GameMainScene
{
    public class MainGameSceneLifeTimeScope : SceneLifeTimeScope<MainGameScenePresenter>
    {
        [UnityEngine.SerializeField] private MainGameSceneView mainGameSceneView;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.Register<MainGameScenePresenter>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.RegisterComponent(mainGameSceneView).AsSelf().AsImplementedInterfaces();
            builder.Register<MainGameSceneModel>(Lifetime.Scoped).AsSelf().AsImplementedInterfaces();
        }
    }
}
