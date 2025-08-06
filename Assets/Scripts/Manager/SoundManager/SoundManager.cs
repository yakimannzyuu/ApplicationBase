
namespace Manager
{
    public interface ISoundManager
    {
        public void PlaySE(SEType type);
    }

    public class SoundManager : ISoundManager
    {
        public void PlaySE(SEType type)
        {
            UnityEngine.Debug.Log($"TODO: Play SE: {type}");
        }
    }

    public enum SEType
    {
        Click,
    }
}
