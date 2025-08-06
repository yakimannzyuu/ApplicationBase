using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace TitleScene
{
    public class TitleSceneModel : MonoBehaviour
    {
        public Action<string> SetVersionText;

        public async UniTask StartAsync()
        {
            await UniTask.CompletedTask;
            var version = $"ver.{Application.version}";
            SetVersionText.Invoke(version);
        }
    }
}
