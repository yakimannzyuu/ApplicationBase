using System.Threading;
using CommonUI;
using Cysharp.Threading.Tasks;
using Manager;
using UnityEngine;
using VContainer;
using WizardAsync;

namespace TitleScene
{
    public class TitleSceneView : MonoBehaviour
    {
        [SerializeField] private CommonUIText versionText;
        [SerializeField] private TitleButton titleButton;

        [Inject]
        public void Inject(IObjectResolver resolver)
        {
            resolver.Inject(titleButton);
        }

        public void SetVersionText(string value)
        {
            versionText.Text = value;
        }

        public IWizardAsync GetWizardAsync()
        {
            return titleButton;
        }
    }

    [System.Serializable]
    public class TitleButton : IWizardAsync
    {
        private ISoundManager _soundManager;

        [Inject]
        public void Inject(ISoundManager soundManager)
        {
            _soundManager = soundManager;
        }

        [SerializeField] private CommonUIButton startButton;

        private WizardAsyncState _currentState;

        public async UniTask<WizardAsyncState> WaitInputAsync(CancellationToken cancellationToken = default)
        {
            _currentState = WizardAsyncState.None;

            startButton.OnClick.SetListener(() => _currentState = WizardAsyncState.Primary);

            await UniTask.WaitUntil(() => _currentState != WizardAsyncState.None, cancellationToken: cancellationToken);

            _soundManager.PlaySE(SEType.Click);

            return _currentState;
        }

        public void SetInput(WizardAsyncState state)
        {
            _currentState = state;
        }
    }
}
