using System.Windows;

namespace calculator3000
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        static Double Eval(String expression)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            return Convert.ToDouble(table.Compute(expression, String.Empty));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender.ToString()[^1].ToString() == "+" || sender.ToString()[^1].ToString() == "-" || sender.ToString()[^1].ToString() == "x" || sender.ToString()[^1].ToString() == "/")
            {
                _outputText.Text += " ";
                _outputText.Text += sender.ToString()[^1].ToString();
                _outputText.Text += " ";
            }
            else
            {
                if (_outputText.Text == "0")
                {
                    _outputText.Text = sender.ToString()[^1].ToString();
                }
                else
                {
                    _outputText.Text += sender.ToString()[^1].ToString();
                }
            }
            Blink();

        }
        private void Blink()
        {
            if (_chertocka.Text == "|")
            {
                _chertocka.Text = "";
            }
            else
            {
                _chertocka.Text = "|";
            }
        }
        private void DeleteOneCharacter(object sender, RoutedEventArgs e)
        {
            _outputText.Text = _outputText.Text.Remove(_outputText.Text.Length - 1);
            CheckIfnotEmpty();
        }
        private void DeleteAllCharacters(object sender, RoutedEventArgs e)
        {
            _outputText.Text = "";
            CheckIfnotEmpty();
        }
        private void CheckIfnotEmpty()
        {
            if (_outputText.Text == "")
            {
                _outputText.Text = "0";
            }
        }
    }
}