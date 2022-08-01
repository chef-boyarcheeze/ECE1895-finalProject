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
using System.Windows.Shapes;

namespace FamilyTree_ECE1895
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddItemWindow : Window
    {
        Rectangle newRec;

        public AddItemWindow(Rectangle recIn)
        {
            InitializeComponent();

            newRec = recIn;
        }

        public void TextChanged(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (sender == addName)
                {
                    newRec.ToolTip += addName.Text;
                }
                else if (sender == addAge)
                {
                    newRec.ToolTip += addAge.Text;
                }
            }
        }

        public void AddPerson(object sender, RoutedEventArgs e)
        {
            if (sender == addPerson)
            {
                int age;

                if (int.TryParse(addAge.Text,out age))
                {
                    newRec.ToolTip = addName.Text;
                    Vertex NewPerson = new Vertex(addName.Text, age);

                    ((MainWindow)Application.Current.MainWindow).Canvas.Children.Add(newRec);
                    ((MainWindow)Application.Current.MainWindow).NameList.Add(NewPerson);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Set age to an integer value and try again!");
                }
            }
        }
    }
}
