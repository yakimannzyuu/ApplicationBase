using TMPro;
using UnityEngine;

namespace CommonUI
{
    [RequireComponent(typeof(TextMesh))]
    public class CommonUIText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;

        public string Text
        {
            get => textMeshProUGUI.text;
            set => textMeshProUGUI.text = value;
        }
    }
}
