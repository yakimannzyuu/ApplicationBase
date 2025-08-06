using UnityEngine;

namespace TitleScene
{
    public class TitleSceneView : MonoBehaviour
    {
        [SerializeField] private CommonUI.CommonUIText versionText;

        public void SetVersionText(string value)
        {
            versionText.Text = value;
        }
    }
}
