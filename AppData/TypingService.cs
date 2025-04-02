using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FastType.AppData
{
    public class TypingService
    {
        // Создаем поля для хранения  и использования переменных для внунтренней логики класса

        private Stopwatch _stopwatch;


        // Создаем свойство для ПОЛУЧЕНИЯ И ПРИСВАЕВАНИЯ  расчетов 
        public double TypeSpeed { get; private set; }

        // Создаем поля для хранения и использования в рамках класса
        private Grid _keyboardDrid;
        private TextBox _typingTextBox;
        private TextBlock _typingTextBlock;
        private TextBlock _speedTextBlock;
        private ProgressBar _progressBar;
        // Создаем конструктор класса для ПРИЕМА элемента управления из интерфейса (TypingTutorPage.xaml)

        public TypingService(Grid keyboardDrid, TextBox typingTextBox, TextBlock typingTextBlock, TextBlock speedTextBlock, ProgressBar progressBar)
        {
            _stopwatch = new Stopwatch();
            _keyboardDrid = keyboardDrid;
            _typingTextBox = typingTextBox;
            _typingTextBlock = typingTextBlock;
            _speedTextBlock = speedTextBlock;
            _progressBar = progressBar;

            _typingTextBox.PreviewKeyDown += _typingTextBox_PreviewKeyDown;
            _typingTextBox.PreviewKeyUp += _typingTextBox_PreviewKeyUp;
            _typingTextBox.TextChanged += _typingTextBox_TextChanged;

        }

        private void _typingTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_typingTextBox.Text.Length >= 1 && !_stopwatch.IsRunning)
            {
                _stopwatch.Start();
            }

            if (_typingTextBlock.Text == _typingTextBox.Text)
            {
                _stopwatch.Stop();
            }

            if (_typingTextBox.Text.Length >= 2)
            {
                _speedTextBlock.Text = CalcutateSpeed();
            }
            AppdateProgress();
        }

        private void _typingTextBox_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var button = FindButtonByKey(e.Key);
            if (button != null)
            {
                button.BorderThickness = new Thickness(0.0, 0.0, 0.0, 0.0);
            }
        }

        private void _typingTextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var button = FindButtonByKey(e.Key);
            if (button != null)
            {
                button.BorderThickness = new Thickness(2.0, 2.0, 2.0, 4.0);
            }

        }
        private Button FindButtonByKey(Key key)
        {
            foreach (var stackPanel in _keyboardDrid.Children.OfType<StackPanel>())
            {
                foreach (var button in stackPanel.Children.OfType<Button>())
                {
                    if (button.Tag.ToString() == key.ToString())
                    {
                        return button;
                    }
                }
            }
            return null;
        }

        private string CalcutateSpeed()
        {
            TypeSpeed = _typingTextBox.Text.Length / _stopwatch.Elapsed.TotalMinutes;
            return $" {TypeSpeed:F0} СВМ";
        }
        private void AppdateProgress()
        {
            double result = _typingTextBox.Text.Length * 100.0 / _typingTextBlock.Text.Length;
            _progressBar.Value = Math.Floor(result);

        }
    }
}
