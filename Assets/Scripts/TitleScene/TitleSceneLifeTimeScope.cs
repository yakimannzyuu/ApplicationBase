using Manager.VContainer;
using VContainer;
using VContainer.Unity;

namespace TitleScene
{
    public class TitleSceneLifeTimeScope : SceneLifeTimeScope<TitleScenePresenter>
    {
        [UnityEngine.SerializeField] private TitleSceneView titleSceneView;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.Register<TitleScenePresenter>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.RegisterComponent(titleSceneView).AsSelf().AsImplementedInterfaces();
            builder.Register<TitleSceneModel>(Lifetime.Scoped).AsSelf().AsImplementedInterfaces();
        }
    }
}
