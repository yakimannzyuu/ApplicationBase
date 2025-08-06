using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using WizardAsync;

namespace TitleScene
{
    public class TitleSceneModel : MonoBehaviour
    {
        public Action<string> SetVersionText;
        public Func<IWizardAsync> GetWizardAsync;

        public async UniTask<WizardAsyncState> StartAsync(CancellationToken cancellationToken)
        {
            await UniTask.CompletedTask;
            var version = $"ver.{Application.version}";
            SetVersionText.Invoke(version);

            var wizardAsync = GetWizardAsync.Invoke();
            WizardAsyncState state = WizardAsyncState.None;

            while (state != WizardAsyncState.Primary)
            {
                state = await wizardAsync.WaitInputAsync(cancellationToken);
                Debug.Log($"TitleSceneModel: Received input state: {state}");
            }
            return state;
        }
    }
}
