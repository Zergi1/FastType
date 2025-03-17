using System.Windows.Controls;

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

        }

        private void _typingTextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            _typingTextBox.Clear();
            _typingTextBox.Text = e.Key.ToString();

        }
    }
}
