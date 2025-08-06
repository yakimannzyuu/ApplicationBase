using System.Threading;
using Cysharp.Threading.Tasks;
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

        // VContainer
        public TitleScenePresenter(TitleSceneModel model, TitleSceneView view)
        {
            _model = model;
            _view = view;
        }

        // VContainer
        public async UniTask StartAsync(CancellationToken cancellationToken)
        {
            Bind();
            await _model.StartAsync();
        }

        private void Bind()
        {
            _model.SetVersionText = _view.SetVersionText;
        }
    }
}
