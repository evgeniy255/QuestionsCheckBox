using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpfbox2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            LimitSelection((CheckBox)sender);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            LimitSelection((CheckBox)sender);
        }

        private void LimitSelection(CheckBox checkBox)
        {
            int count = 0;
            var parentStackPanel = (StackPanel)checkBox.Parent;
            int maxSelections = parentStackPanel.Name == "Question3" ? 3 : 2;

            foreach (var child in parentStackPanel.Children)
            {
                if (child is CheckBox cb && cb.IsChecked == true)
                {
                    count++;
                }
            }

            if (count > maxSelections)
            {
                checkBox.IsChecked = false;
                MessageBox.Show($"Выберите не более {maxSelections} вариантов ответа.");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            byte correctAnswers = 0;

            if (Q1_1.IsChecked == true) correctAnswers++;
            if (Q1_4.IsChecked == true) correctAnswers++;
            if (Q2_2.IsChecked == true) correctAnswers++;
            if (Q2_4.IsChecked == true) correctAnswers++;
            if (Q3_1.IsChecked == true) correctAnswers++;
            if (Q3_3.IsChecked == true) correctAnswers++;
            if (Q3_4.IsChecked == true) correctAnswers++;
            if (Q4_2.IsChecked == true) correctAnswers++;
            if (Q4_4.IsChecked == true) correctAnswers++;

            MessageBox.Show($"Вы ответили правильно на {correctAnswers}/9 вопросов!");
        }
    }
}
