using Cysharp.Threading.Tasks;
using UnityEngine;

namespace RootLifeTimeScope
{
    public interface IGameManager
    {
        public void Test();
    }

    // GameManager
    public class RootPresenter : IGameManager
    {
        public async UniTask StartAsync()
        {
            Debug.Log("RootLifeTimeScopePresenter started.");
            await UniTask.CompletedTask;

            await UniTask.Delay(1000); // Simulate some initialization delay
            Debug.Log("RootLifeTimeScopePresenter initialization complete.");
        }

        public void Test()
        {
            Debug.Log("RootLifeTimeScopePresenter Test method called.");
        }
    }
}
