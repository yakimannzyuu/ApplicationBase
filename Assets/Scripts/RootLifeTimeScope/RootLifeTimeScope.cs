using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Manager;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer;
using VContainer.Unity;

namespace RootLifeTimeScope
{
    /// <summary>
    /// 全シーンで共通で使用されるプレファブ
    /// </summary
    public class RootLifeTimeScope : LifetimeScope
    {
        private const string PrefabPath = "RootLifeTimeScope";
        public static RootLifeTimeScope Instance { get; private set; }

        // VContainer
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<RootPresenter>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.RegisterEntryPoint<EntryPoint>();

            builder.Register<SoundManager>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<SceneLoader>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
        }

        public void Init()
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        /// <summary>
        /// シーンを開始時に呼び出す
        /// </summary>
        /// <remarks>
        /// RooTLifeTimeScopeのインスタンスが存在しない場合に、プレファブをロードして初期化します。
        /// </remarks>
        public static async UniTask Bootstrap()
        {
            if (Instance != null)
                return;

            Addressables.InstantiateAsync(PrefabPath).Completed += handle =>
            {
                if (handle.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
                    return;

                Debug.LogError("Failed to load RootLifeTimeScope.");
            };

            await UniTask.WaitUntil(() => Instance != null);
        }

        public class EntryPoint : IAsyncStartable
        {
            private readonly RootLifeTimeScope _rootLifeTimeScope;
            private readonly RootPresenter _presenter;

            // VContainer
            public EntryPoint(
                RootLifeTimeScope rootLifeTimeScope,
                RootPresenter presenter
            )
            {
                _rootLifeTimeScope = rootLifeTimeScope;
                _presenter = presenter;
            }

            // VContainer
            public async UniTask StartAsync(CancellationToken cancellationToken)
            {
                await _presenter.StartAsync();
                _rootLifeTimeScope.Init();
            }
        }
    }
}
