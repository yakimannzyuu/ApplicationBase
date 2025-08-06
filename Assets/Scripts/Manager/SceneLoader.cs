using Cysharp.Threading.Tasks;
using Manager.VContainer;
using UnityEngine;

namespace Manager
{
    public interface ISceneLoader
    {
        /// <summary>
        /// シーンをロードする
        /// </summary>
        public UniTask<T> LoadScene<T>(SceneType sceneType, LoadSceneMode loadSceneMode) where T : IScenePresenter;
    }

    public class SceneLoader : ISceneLoader
    {
        public async UniTask<T> LoadScene<T>(SceneType sceneType, LoadSceneMode loadSceneMode) where T : IScenePresenter
        {
            UnityEngine.SceneManagement.LoadSceneMode mode =
                loadSceneMode == LoadSceneMode.Single ?
                UnityEngine.SceneManagement.LoadSceneMode.Single :
                UnityEngine.SceneManagement.LoadSceneMode.Additive;
            await UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneType.ToString(), mode);


            return default;
        }
    }

    public enum SceneType
    {
        TitleScene,
        MainGameScene,
    }

    public enum LoadSceneMode
    {
        Single,
        Additive,
    }
}
