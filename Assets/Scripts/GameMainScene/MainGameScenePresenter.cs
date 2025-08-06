using System.Threading;
using Cysharp.Threading.Tasks;
using Manager.VContainer;

namespace GameMainScene
{
    public class MainGameScenePresenter : IScenePresenter
    {
        public async UniTask StartAsync(CancellationToken cancellationToken)
        {
            await UniTask.CompletedTask;
            UnityEngine.Debug.Log("MainGameScenePresenter: StartAsync called.");
        }
    }
}
