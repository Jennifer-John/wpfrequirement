using System.Windows;
using System.Windows.Media;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WPFRequirement: Window
    {
        Queue<string> lst_str = new Queue<string>();

        public WPFRequirement()
        {
            InitializeComponent();
            setFocus();
        }

        private void DisplayButton_Click(object sender, RoutedEventArgs e)
        {
            if (txt_input.Text.Trim().Length > 0)
            {
                lst_str.Enqueue(txt_input.Text);
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
            if (lst_str.Count > 0)
            {
                string bottom_element = lst_str.Peek();
                process_label.Content = bottom_element;
                assign_colour_code(bottom_element);
                update_display_label();
            }
        }

        private void update_display_label()
        {
            lst_str.Dequeue();
            display_label.Content = lst_str.Count;
            string updated_string = string.Join("", lst_str.Reverse().ToArray());
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