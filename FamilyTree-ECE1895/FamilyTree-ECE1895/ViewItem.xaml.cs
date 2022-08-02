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
    public partial class ViewItemWindow : Window
    {
        int index;

        Rectangle activeRec;
        public ViewItemWindow(Rectangle recIn, int i)
        {
            InitializeComponent();

            index = i;

            activeRec = recIn;
            name.Text = ((MainWindow)Application.Current.MainWindow).NameList[index].Name;
            age.Text = ((MainWindow)Application.Current.MainWindow).NameList[index].Age.ToString();
        }

        public void RemovePerson(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).Canvas.Children.Remove(activeRec);
            ((MainWindow)Application.Current.MainWindow).NameList.RemoveAt(index);

            ((MainWindow)Application.Current.MainWindow).familySize--;
            ((MainWindow)Application.Current.MainWindow).FamilySize.Text = "Family Size: " + ((MainWindow)Application.Current.MainWindow).familySize;

            this.Close();
        }
    }
}
