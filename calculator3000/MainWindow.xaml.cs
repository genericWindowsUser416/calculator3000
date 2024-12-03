using System.Data;
using System.Globalization;
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

        public static string Eval(string expression)
        {
            string result;
            try 
            {
                result = Convert.ToDouble(new DataTable().Compute(expression, string.Empty)).ToString("F2", CultureInfo.InvariantCulture);
            }
            catch 
            {
                result = "0";
            }
            if (result == "Infinity" || result == "NaN") 
            {
                result = "11010000101111011101000010110101";
            }
            return result;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender.ToString()[^1].ToString() == "+" || sender.ToString()[^1].ToString() == "-" || sender.ToString()[^1].ToString() == "*" || sender.ToString()[^1].ToString() == "/")
            {
                if (_outputText.Text[^1].ToString() != " ")
                {
                    _outputText.Text += " ";
                    _outputText.Text += sender.ToString()[^1].ToString();
                    _outputText.Text += " ";
                }
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

        private void AnswerEqualsTo(object sender, RoutedEventArgs e)
        {
            if (_outputText.Text[^1].ToString() != " ")
            {
                _outputText.Text = String.Format("{0:0.00}", Eval(_outputText.Text).ToString());
            }
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