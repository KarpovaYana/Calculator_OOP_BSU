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

namespace Калькулятор_ООП_Карпова
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool shiftDown = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textCalc.Text = textCalc.Text.ToString()+((Button)sender).Name.ToCharArray()[1];
        }

        private string checkSign(string sign)
        {
            switch(sign)
            {
                case "procent": return "%";
                case "div": return "/";
                case "multiply": return "*";
                case "minus": return "-";
                case "plus": return "+";
                case "scopeLeft": return "(";
                case "scopeRight": return ")";
            }
            return "";
        }

        private void sign_Click(object sender, RoutedEventArgs e)
        {
            textCalc.Text = textCalc.Text.ToString()+checkSign(((Button)sender).Name.ToString());
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            textCalc.Text = "";
        }

        private void equals_Click(object sender, RoutedEventArgs e)
        {
            textCalc.Text = RPN.Calculate(textCalc.Text.ToString()).ToString();
        }

        private void textCalc_KeyDown(object sender, KeyEventArgs e)
        {
            
            e.Handled = false;
            char key='a';
            foreach(char c in e.Key.ToString())
                key = c;
            if (key == 't') shiftDown = true;
        }

        private void textCalc_KeyUp(object sender, KeyEventArgs e)
        {
            char key = 'a';
            e.Handled = false;
            foreach (char c in e.Key.ToString())
                key = c;
            if (key == 't')
            {
                shiftDown = false;
                return;
            }
            if(shiftDown)
            {
                if (key == '5') key = '%';
                if (key == '8') key = '*';
                if (key == '9') key = '(';
                if (key == '0') key = ')';
            }
            if (!((key >= 47 && key < 57) || key == '%' || key == '*' || key == 's' || key == '-' || key == 'n' || key == '(' || key == ')'))
            {
                textCalc.Text = textCalc.Text.Remove(textCalc.Text.Length - 1);
                textCalc.Select(textCalc.Text.Length,0);
            }
        }

        private void minusx_Click(object sender, RoutedEventArgs e)
        {
            textCalc.Text = textCalc.Text.Remove(textCalc.Text.Length - 1);
            textCalc.Select(textCalc.Text.Length, 0);
        }
    }
}
