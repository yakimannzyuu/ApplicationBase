using System.Threading;
using Cysharp.Threading.Tasks;

namespace WizardAsync
{
    public interface IWizardAsync
    {
        /// <summary>
        /// 操作を待機する
        /// </summary>
        /// <returns>操作の結果</returns>
        /// <param name="cancellationToken">キャンセルトークン</param>
        public UniTask<WizardAsyncState> WaitInputAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 外部から操作を更新する
        /// </summary>
        public void SetInput(WizardAsyncState state);
    }

    public enum WizardAsyncState
    {
        /// <summary>未選択</summary><remarks>待機状態等</remarks>
        None = -1,
        /// <summary>キャンセル</summary><remarks>暗幕クリック等</remarks>
        Cancelled,
        /// <summary>第一操作</summary><remarks>はい</remarks>
        Primary,
        /// <summary>第二操作</summary><remarks>いいえ</remarks>
        Secondary,
    }
}
