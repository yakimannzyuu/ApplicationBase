using System.Threading;
using Cysharp.Threading.Tasks;
using Manager;
using Manager.VContainer;
using UnityEngine;

namespace TitleScene
{
    /// <summary>
    /// TitleSceneのPresenter
    /// </summary>
    public class TitleScenePresenter : MonoBehaviour, IPresenter
    {
        private readonly TitleSceneModel _model;
        private readonly TitleSceneView _view;
        private readonly ISceneLoader _sceneLoader;

        // VContainer
        public TitleScenePresenter(TitleSceneModel model, TitleSceneView view, ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _model = model;
            _view = view;
        }

        // VContainer
        public async UniTask StartAsync(CancellationToken cancellationToken)
        {
            Bind();
            var result = await _model.StartAsync(cancellationToken);

            switch (result)
            {
                case WizardAsync.WizardAsyncState.Primary:
                    await _sceneLoader.LoadScene<IScenePresenter>(SceneType.GameScene, LoadSceneMode.Single);
                    break;
                default:
                    Debug.LogWarning($"TitleScenePresenter: Unexpected state received: {result}");
                    break;
            }
        }

        private void Bind()
        {
            _model.SetVersionText = _view.SetVersionText;
            _model.GetWizardAsync = _view.GetWizardAsync;
        }
    }
}
