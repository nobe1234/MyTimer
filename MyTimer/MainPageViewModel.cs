using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyTimer
{
    // 起動直後のタイマー設定画面の ViewModel
    class MainPageViewModel : BindableBase
    {
        // **画面の値とバインディングするプロパティ**

        // タイマー時間
        private TimeSpan _time = TimeSpan.FromMinutes(5);
        public TimeSpan Time { get { return _time; } set { SetProperty(ref _time, value); } }

        // タイマー時間経過後の案内音声
        private string _speechText = "Time haspassed";
        public string SpeechText { get { return _speechText; } set { SetProperty(ref _speechText, value); } }

        // タイマー時間経過後に案内音声を使うか？（使わない場合、Audio 再生）
        private bool _useSpeechText = true;
        public bool UseSpeechText { get { return _useSpeechText; } set { SetProperty(ref _useSpeechText, value); } }

        // **画面のボタンとバインディングするコマンド**

        //  開始ボタンが押された
        public Command StartCommand { get; }

        //  秒 +/- ボタンが押された
        public Command AddSecondsCommand { get; }

        //  分 +/- ボタンを押された
        public Command AddMinutesCommand { get; }

        // **複数個所で行われる処理をメソッド化したメソッド**

        // object (中身は string) を long に parse する
        private long ParseLong(object arg) 
        {
            if (long.TryParse(arg?.ToString(), out var value))
                return value;
            return default(long);
        }

        // タイマー時間を追加する。
        private void AddTime(long seconds)
        {
            var newTime = Time.TotalSeconds + seconds;

            // 必ず 1 秒以上 60 分未満となるよう調整する
            newTime = Math.Max(1,newTime);
            newTime = Math.Min((60 * 60) - 1, newTime);

            Time = TimeSpan.FromSeconds(newTime);
        }

        private void AddSeconds(Object parameter)
        {
            long value = ParseLong(parameter);
            AddTime(value);
        }

        private void AddMinutes(Object parameter)
        {
            long value = ParseLong(parameter);
            AddTime(value * 60);
        }

        // 開始ボタンが押された時の処理
        private void Start()
        {

        }

        // コンストラクタ
        public MainPageViewModel()
        {
            // コマンドの設定
            // readonly プロパティの初期化はコンストラクタ内でも行える
            AddSecondsCommand = new Command(AddSeconds);
            AddMinutesCommand = new Command(AddMinutes);
            StartCommand = new Command(Start);
            
        }


    }
}
