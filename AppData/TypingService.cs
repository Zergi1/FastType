using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FastType.AppData
{
    public class TypingService
    {
        // Создаем поля для хранения и использования в рамках класса
        private Grid _keyboardDrid;
        private TextBox _typingTextBox;
        private TextBlock _typingTextBlock;
        // Создаем конструктор класса для ПРИЕМА элемента управления из интерфейса (TypingTutorPage.xaml)

        public TypingService(Grid keyboardDrid, TextBox typingTextBox, TextBlock typingTextBlock)
        {
            _keyboardDrid = keyboardDrid;
            _typingTextBox = typingTextBox;
            _typingTextBlock = typingTextBlock;
            _typingTextBox.PreviewKeyDown += _typingTextBox_PreviewKeyDown;
            _typingTextBox.PreviewKeyUp += _typingTextBox_PreviewKeyUp;
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
    }
}
