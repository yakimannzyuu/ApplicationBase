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
            await UniTask.CompletedTask;
        }

        public void Test()
        {
            Debug.Log("RootLifeTimeScopePresenter Test method called.");
        }
    }
}
