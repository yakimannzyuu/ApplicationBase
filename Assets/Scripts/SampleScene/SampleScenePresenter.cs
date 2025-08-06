using Cysharp.Threading.Tasks;
using RootLifeTimeScope;
using UnityEngine;
using VContainer.Unity;

namespace SampleScene
{
    public class SampleScenePresenter
    {
        private readonly IGameManager _gameManager;

        public SampleScenePresenter(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public async UniTask StartAsync()
        {
            Debug.Log("SampleScenePresenter started.");
            await UniTask.CompletedTask;
            _gameManager.Test();
        }
    }
}
