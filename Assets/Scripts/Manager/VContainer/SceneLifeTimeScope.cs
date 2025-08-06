using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Manager.VContainer
{
    /// <summary>
    /// シーン用LifeTimeScopeのベースクラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SceneLifeTimeScope<T> : LifetimeScope where T : IPresenter
    {
        // MonoBehaviour
        private void Start()
        {
            RootLifeTimeScope.RootLifeTimeScope.Bootstrap().Forget(ex =>
            {
                Debug.LogError($"Failed to bootstrap SceneLifeTimeScope: \n{ex}");
            });
        }

        // VContainer
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.RegisterEntryPoint<EntryPoint>();
        }

        public class EntryPoint : IAsyncStartable
        {
            private readonly T _presenter;

            // VContainer
            public EntryPoint(T presenter)
            {
                _presenter = presenter;
            }

            // VContainer
            public async UniTask StartAsync(CancellationToken cancellationToken)
            {
                await UniTask.WaitUntil(() => RootLifeTimeScope.RootLifeTimeScope.Instance != null, cancellationToken: cancellationToken);
                await _presenter.StartAsync(cancellationToken);
            }
        }
    }

    public interface IPresenter
    {
        public UniTask StartAsync(CancellationToken cancellationToken);
    }
}
