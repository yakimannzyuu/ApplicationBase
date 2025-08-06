using UnityEngine;

namespace CommonUI
{
    public class CommonUIButtonText : CommonUIButton
    {
        [SerializeField] private CommonUIText buttonText;

        public string Text
        {
            get => buttonText.Text;
            set => buttonText.Text = value;
        }
    }
}
