using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for WPFRequirement.xaml
    /// </summary>
    public partial class WPFRequirement: Window
    {
        Queue<string> queue_input = new Queue<string>();

        public WPFRequirement()
        {
            InitializeComponent();
            setFocus();
        }

        private void DisplayButton_Click(object sender, RoutedEventArgs e)
        {
            if (txt_input.Text.Trim().Length > 0)
            {
                queue_input.Enqueue(txt_input.Text);
                string enteredText = txt_input.Text + display_label.Content.ToString();
                display_label.Content = enteredText;
                txt_input.Clear();
            }
            setFocus();
        }

        private void setFocus()
        {
            txt_input.Focus();
        }

        private void ProcessButton_Click(object sender, RoutedEventArgs e)
        {
            if (queue_input.Count > 0)
            {
                string bottom_element = queue_input.Peek();
                process_label.Content = bottom_element;
                assign_colour_code(bottom_element);
                update_display_label();
            }
        }

        private void update_display_label()
        {
            queue_input.Dequeue();
            display_label.Content = queue_input.Count;
            string updated_string = string.Join("", queue_input.Reverse().ToArray());
            display_label.Content = updated_string;
        }

        private void assign_colour_code(string elem)
        {
            char first_element = elem[0];
            if(char.IsDigit(first_element))
            {
                process_label.Foreground = new SolidColorBrush(Colors.Blue);
            }
            else if(char.IsLetter(first_element))
            {
                process_label.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                process_label.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
