using UnityEngine;
using UnityEngine.Events;

namespace CommonUI
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public class CommonUIButton : MonoBehaviour
    {
        [SerializeField] private UnityEngine.UI.Button button;

        public UnityEvent OnClick
        {
            get => button.onClick;
        }
    }

    public static class UnityEventExtensions
    {
        public static void SetListener(this UnityEvent unityEvent, UnityAction action)
        {
            if (unityEvent == null || action == null) return;
            unityEvent.RemoveAllListeners();
            unityEvent.AddListener(action);
        }
    }
}
