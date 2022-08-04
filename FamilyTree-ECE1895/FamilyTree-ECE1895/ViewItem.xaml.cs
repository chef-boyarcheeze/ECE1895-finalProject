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
        public ViewItemWindow(Rectangle recIn, int value)
        {
            InitializeComponent();

            index = value;

            activeRec = recIn;
            name.Text = ((MainWindow)Application.Current.MainWindow).NameList[index].Name;
            age.Text = ((MainWindow)Application.Current.MainWindow).NameList[index].Age.ToString();

            for (int i = 0; i < ((MainWindow)Application.Current.MainWindow).NameList.Count; i++)
            {
                SelectedPerson.Items.Add(((MainWindow)Application.Current.MainWindow).NameList[i].Name);
            }
        }

        public void RemovePerson(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < ((MainWindow)Application.Current.MainWindow).EdgeList.Count; i++)
            {
                if (((MainWindow)Application.Current.MainWindow).EdgeList[i].Name1 == ((MainWindow)Application.Current.MainWindow).NameList[index] ||
                    ((MainWindow)Application.Current.MainWindow).EdgeList[i].Name1 == ((MainWindow)Application.Current.MainWindow).NameList[index])
                {
                    ((MainWindow)Application.Current.MainWindow).EdgeList.RemoveAt(i);
                    i--;
                }
            }

            ((MainWindow)Application.Current.MainWindow).Canvas.Children.Remove(activeRec);
            ((MainWindow)Application.Current.MainWindow).NameList.RemoveAt(index);

            this.Close();
        }

        public void AddLink(object sender, RoutedEventArgs e)
        {
            int gap;

            if (int.TryParse(GenerationGap.Text, out gap))
            {
                Edge link = new Edge(((MainWindow)Application.Current.MainWindow).NameList[index],((MainWindow)Application.Current.MainWindow).NameList[SelectedPerson.SelectedIndex],gap);

                ((MainWindow)Application.Current.MainWindow).EdgeList.Add(link);

                int count = ((MainWindow)Application.Current.MainWindow).EdgeList.Count;

                for (int i = 0; i < count; i++)
                {
                    if (((MainWindow)Application.Current.MainWindow).EdgeList[i] != link && !(((MainWindow)Application.Current.MainWindow).EdgeList[i] | link))
                    {
                        if (((MainWindow)Application.Current.MainWindow).EdgeList[i].Name1 == ((MainWindow)Application.Current.MainWindow).NameList[SelectedPerson.SelectedIndex])
                        {
                            link = new Edge(((MainWindow)Application.Current.MainWindow).NameList[index], ((MainWindow)Application.Current.MainWindow).EdgeList[i].Name2, ((MainWindow)Application.Current.MainWindow).EdgeList[i].Level);
                            ((MainWindow)Application.Current.MainWindow).EdgeList.Add(link);
                        }
                        else if (((MainWindow)Application.Current.MainWindow).EdgeList[i].Name2 == ((MainWindow)Application.Current.MainWindow).NameList[SelectedPerson.SelectedIndex])
                        {
                            link = new Edge(((MainWindow)Application.Current.MainWindow).NameList[index], ((MainWindow)Application.Current.MainWindow).EdgeList[i].Name1, ((MainWindow)Application.Current.MainWindow).EdgeList[i].Level);
                            ((MainWindow)Application.Current.MainWindow).EdgeList.Add(link);
                        }
                        else if (((MainWindow)Application.Current.MainWindow).EdgeList[i].Name1 == ((MainWindow)Application.Current.MainWindow).NameList[index])
                        {
                            link = new Edge(((MainWindow)Application.Current.MainWindow).NameList[SelectedPerson.SelectedIndex], ((MainWindow)Application.Current.MainWindow).EdgeList[i].Name2, ((MainWindow)Application.Current.MainWindow).EdgeList[i].Level);
                            ((MainWindow)Application.Current.MainWindow).EdgeList.Add(link);
                        }
                        else if (((MainWindow)Application.Current.MainWindow).EdgeList[i].Name2 == ((MainWindow)Application.Current.MainWindow).NameList[index])
                        {
                            link = new Edge(((MainWindow)Application.Current.MainWindow).NameList[SelectedPerson.SelectedIndex], ((MainWindow)Application.Current.MainWindow).EdgeList[i].Name2, ((MainWindow)Application.Current.MainWindow).EdgeList[i].Level);
                            ((MainWindow)Application.Current.MainWindow).EdgeList.Add(link);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Set generational gap to an integer value and try again!");
            }
        }

        private void SelectedPerson_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedPerson.SelectedIndex == index)
            {
                SelectedPerson.SelectedIndex = -1;
                MessageBox.Show("Select a different person!");
            }
        }
    }
}
