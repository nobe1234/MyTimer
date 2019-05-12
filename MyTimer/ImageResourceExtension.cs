using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace MyTimer
{
    // 共通プロジェクトのリソース画像を表示のためのマークアップ拡張
    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        // リソースファイルのパスを取得または設定する
        public string Source { get; set; }

        // Sourceで指定されたリソース情報を取得する。
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
                return null;
            // リソースからパスの情報読み込む
            var imageSource = ImageSource.FromResource(Source);

            return imageSource;
        }
    }
}
