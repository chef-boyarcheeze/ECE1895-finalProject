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
        private bool nameSet = false, relationSet = false, ageSet = false;
        Rectangle newRec;

        public AddItemWindow(Rectangle recIn)
        {
            InitializeComponent();

            newRec = recIn;
        }

        private void TextChanged(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (sender == addName)
                {
                    ((MainWindow)Application.Current.MainWindow).name = addName.Text;
                    nameSet = true;

                    newRec.ToolTip += addName.Text;

                    if (nameSet && relationSet && ageSet)
                    {
                        ((MainWindow)Application.Current.MainWindow).done = true;
                        ((MainWindow)Application.Current.MainWindow).Canvas.Children.Add(newRec);
                        MessageBox.Show(newRec.ToolTip.ToString());
                        this.Close();
                    }
                }
                else if (sender == addRelation)
                {
                    ((MainWindow)Application.Current.MainWindow).relation = addRelation.Text;
                    relationSet = true;

                    newRec.ToolTip += addRelation.Text;

                    if (nameSet && relationSet && ageSet)
                    {
                        ((MainWindow)Application.Current.MainWindow).done = true;
                        ((MainWindow)Application.Current.MainWindow).Canvas.Children.Add(newRec);
                        MessageBox.Show(newRec.ToolTip.ToString());
                        this.Close();
                    }
                }
                else if (sender == addAge)
                {
                    //((MainWindow)Application.Current.MainWindow).age = int.Parse(addName.Text);
                    ageSet = true;

                    newRec.ToolTip += addAge.Text;

                    if (nameSet && relationSet && ageSet)
                    {
                        ((MainWindow)Application.Current.MainWindow).done = true;
                        ((MainWindow)Application.Current.MainWindow).Canvas.Children.Add(newRec);
                        MessageBox.Show(newRec.ToolTip.ToString());
                        this.Close();
                    }
                }
            }
        }
    }
}
