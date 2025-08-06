using System.Threading;
using Cysharp.Threading.Tasks;
using VContainer;
using VContainer.Unity;

namespace SampleScene
{
    // VContainer
    public class SampleSceneLifeTimeScope : LifetimeScope
    {
        // MonoBehaviour
        private void Start()
        {
            RootLifeTimeScope.RootLifeTimeScope.Bootstrap().Forget(ex =>
            {
                UnityEngine.Debug.LogError($"Failed to bootstrap SampleSceneLifeTimeScope: \n{ex}");
            });
        }

        // VContainer
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<SampleScenePresenter>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.RegisterEntryPoint<EntryPoint>();
        }

        public class EntryPoint : IAsyncStartable
        {
            private readonly SampleScenePresenter _presenter;

            // VContainer
            public EntryPoint(SampleScenePresenter presenter)
            {
                _presenter = presenter;
            }

            // VContainer
            public async UniTask StartAsync(CancellationToken cancellationToken)
            {
                await UniTask.WaitUntil(() => RootLifeTimeScope.RootLifeTimeScope.Instance != null, cancellationToken: cancellationToken);
                await _presenter.StartAsync();
            }
        }
    }
}
