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

namespace FamilyTree_ECE1895
{
    public struct Vertex
    {
        public Vertex(string name, int age)
        {
            Name = name;
            Age = age;
        }
        
        public string Name;
        public int Age;
    }

    public partial class MainWindow : Window
    {
        Brush CustomBrush;
        Random r = new Random();

        public List<Vertex> NameList = new List<Vertex>();

        public int familySize = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void addItem(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Rectangle)
            {
                Rectangle activeRec = (Rectangle)e.OriginalSource;

                int i = 0;

                while (NameList[i].Name != activeRec.ToolTip.ToString())
                {
                    i++;
                }

                ViewItemWindow newMember = new ViewItemWindow(activeRec,i);
                newMember.Topmost = true;
                newMember.Show();
                newMember.Activate();
            }

            else
            {
                // generate a random brush color:
                CustomBrush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
                (byte)r.Next(1, 255), (byte)r.Next(1, 233)));


                Rectangle newRec = new Rectangle
                {
                    Width = 25,
                    Height = 25,
                    StrokeThickness = 3,
                    Fill = CustomBrush,
                    Stroke = Brushes.Black
                };

                Canvas.SetLeft(newRec, Mouse.GetPosition(Canvas).X); // set the left position of rectangle to mouse X
                Canvas.SetTop(newRec, Mouse.GetPosition(Canvas).Y); // set the top position of rectangle to mouse Y

                AddItemWindow newMember = new AddItemWindow(newRec);
                newMember.Topmost = true;
                newMember.Show();
                newMember.Activate();
            }
        }
    }
}
